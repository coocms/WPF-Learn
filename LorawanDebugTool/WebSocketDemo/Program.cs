﻿
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Client.Http.Websocket;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet;

namespace WebSocketDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var o = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffK");

            //var ll = DateTime.ParseExact("2023-04-20T06:09:07.7719578", "yyyy-MM-ddTHH:mm:ss.fffffff", null);
            
            //var webSocket = new ClientWebSocket();

            //webSocket.Options.SetRequestHeader("Sec-WebSocket-Extensions", "permessage-deflate; client_max_window_bits");

            //var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhcGlfa2V5X2lkIjoiMTA1NTU1NTYtZWE5ZC00ZjBlLWE1MzItY2M2MDI5YzAxNWQyIiwiYXVkIjoiYXMiLCJpc3MiOiJhcyIsIm5iZiI6MTY4MTgwMDYyMSwic3ViIjoiYXBpX2tleSJ9.8j0wqhPDnb4_vVkuyGO7-55SeDwjrs9ElTikU-4zIbs";

            //webSocket.Options.AddSubProtocol("Bearer");
            //webSocket.Options.AddSubProtocol(jwtToken);
            
            //webSocket.ConnectAsync(new Uri("ws://121.5.35.98:8080/api/devices/037980fffe075362/events"), CancellationToken.None).Wait();
            
            ////webSocket.Options.AddSubProtocol
            //while (webSocket.State == WebSocketState.Open)
            //{
            //    var buffer = new ArraySegment<byte>(new byte[2048]);
            //    var result = webSocket.ReceiveAsync(buffer, CancellationToken.None).Result;
            //    Console.WriteLine(Encoding.UTF8.GetString(buffer.Array, 0, result.Count));
            //}


            try
            {

                
                IMqttClient client = new MqttFactory().CreateMqttClient();

                var build = new MqttClientOptionsBuilder()

               //配置客户端Id

               .WithClientId("DotnetConsole1")
               
               //配置登录账号

               //.WithCredentials("test", "1234")

               //配置服务器IP端口 这里得端口号是可空的

               .WithTcpServer("121.5.35.98", 1883);
                
                client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;



                //连接

                var c = client.ConnectAsync(build.Build()).Result;
                //var d = client.SubscribeAsync("application/1/device/+/event/up").Result;

                string test = "{}";
                var bytes = strToToHexByte(test);

                client.PublishAsync(new MqttApplicationMessage() { Topic = "test", Payload = strToToHexByte(test) });
            }

            catch (MqttConnectingFailedException)
            {

                Console.WriteLine("身份校验失败");

            }

            catch (Exception ex)
            {

                var name = ex.GetType().FullName;

                Console.WriteLine("出现异常");

                Console.WriteLine(ex.Message);

            }


            Console.Read();


        }
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            hexString = hexString.Replace(" ", "");


            if (hexString.Length % 2 != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {

                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            }

            return returnBytes;
        }

        private static Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs obj)
        {

            Console.WriteLine("===================================================");

            Console.WriteLine("收到消息:");

            Console.WriteLine($"codeholder_1amp; quot; 主题: {obj.ApplicationMessage.Topic}");

            Console.WriteLine($"codeholder_1amp; quot; 消息: {Encoding.UTF8.GetString(obj.ApplicationMessage.Payload)}");

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.WriteLine();
            return Task.CompletedTask;
        }


        

    }
}