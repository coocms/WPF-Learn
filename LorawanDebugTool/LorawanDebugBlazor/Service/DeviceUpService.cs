using LorawanDebugBlazor.Tool;
using System.Net.WebSockets;
using System.Text;

namespace LorawanDebugBlazor.Service
{
    public class DeviceUpService
    {
        IConfiguration _configuration;
        string addr;
        public DeviceUpService(IConfiguration configuration)
        {
            _configuration = configuration;
            addr = _configuration.GetValue<string>("NSAddr");
            SCHCWrapper.SCHCCompress("");
        }

        public IEnumerable<string> GetDeviceUpData(string devUI, CancellationToken cancellationToken)
        {

            var webSocket = new ClientWebSocket();

            webSocket.Options.SetRequestHeader("Sec-WebSocket-Extensions", "permessage-deflate; client_max_window_bits");

            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhcGlfa2V5X2lkIjoiMTA1NTU1NTYtZWE5ZC00ZjBlLWE1MzItY2M2MDI5YzAxNWQyIiwiYXVkIjoiYXMiLCJpc3MiOiJhcyIsIm5iZiI6MTY4MTgwMDYyMSwic3ViIjoiYXBpX2tleSJ9.8j0wqhPDnb4_vVkuyGO7-55SeDwjrs9ElTikU-4zIbs";

            webSocket.Options.AddSubProtocol("Bearer");
            webSocket.Options.AddSubProtocol(jwtToken);
            string url = $"ws://{addr}/api/devices/{devUI}/events";
            try
            {
                webSocket.ConnectAsync(new Uri(url), cancellationToken).Wait();
            }
            catch (Exception)
            {
                yield break;
            }
            
            //webSocket.ConnectAsync(new Uri($"ws://{addr}/api/devices/{devUI}/events"), CancellationToken.None).Wait();

            //webSocket.Options.AddSubProtocol
            while (webSocket.State == WebSocketState.Open)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                var buffer = new ArraySegment<byte>(new byte[2048]);
                string res;
                try
                {
                    var result = webSocket.ReceiveAsync(buffer, cancellationToken).Result;
                    res = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    
                }
                catch (Exception)
                {

                    break;
                }
                if (res.StartsWith("02"))
                {
                    var msg = DataConvert.strToToHexByte(res);
                    SCHCWrapper.SendData(msg, msg.Length, 1);
                    continue;
                }
                
                
                yield return res;
            }

        }

        public string GetPackageData()
        {
            byte[] resData = new byte[1024];
            int len = 0;
            SCHCWrapper.Pop(ref resData[0], ref len);
            if (len == 0)
                return string.Empty;

            var res = DataConvert.byteToHexStr(resData);
            res = res.Substring(0, len * 2);

            var originalData = SCHCWrapper.SCHCDecompress(res);
            return originalData;

        }
    }
}
