using LorawanDebugBlazor.Tool;
using System.Runtime.InteropServices;

namespace LorawanDebugBlazor.Service
{
    public class SCHCWrapper
    {
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern int Init(); 
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern void SendData(byte[] data, int length, int device_id); 
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Push(byte[] data, int size); 
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern void Pop(ref byte resData, ref int len); 
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern bool compress(byte[] originalData, int size, ref byte compressedData); 
        [DllImport("_3rd\\CToDLL3.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] 
        public static extern bool decompress(byte[] compressedData, int size, ref byte originalData);

        public static string SCHCCompress(string originalData)
        {
            var msg = DataConvert.strToToHexByte(originalData);

            byte[] compressedData = new byte[256];
            var p = compress(msg, msg.Length, ref compressedData[0]);

            var res = DataConvert.byteToHexStr(compressedData);

            return res;
        }

        public static string SCHCDecompress(string compressedData)
        {
            var msg = DataConvert.strToToHexByte(compressedData);
            byte[] originalData = new byte[1024];
            try
            {
                var p = decompress(msg, msg.Length, ref originalData[0]);
                var res = DataConvert.byteToHexStr(originalData);

                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SCHCDecompress Error : {ex.Message} \n {ex.StackTrace}");
                return string.Empty;
            }
        }
    }
}
