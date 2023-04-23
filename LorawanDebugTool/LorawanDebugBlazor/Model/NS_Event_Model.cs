namespace LorawanDebugBlazor.Model
{

    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payloadJSON { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string publishedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string streamID { get; set; }
    }

    public class NS_Event_Model
    {
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
    }



    public class Location
    {
        /// <summary>
        /// 
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int altitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int accuracy { get; set; }
    }

    public class RxInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string gatewayID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timeSinceGPSEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rssi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double loRaSNR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int channel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rfChain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int board { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int antenna { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fineTimestampType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uplinkID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string crcStatus { get; set; }
    }

    public class LoRaModulationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int spreadingFactor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string codeRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool polarizationInversion { get; set; }
    }

    public class TxInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int frequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string modulation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LoRaModulationInfo loRaModulationInfo { get; set; }
    }

    public class Tags
    {
    }

    public class PayloadModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string applicationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string applicationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string devEUI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RxInfo> rxInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TxInfo txInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool adr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fCnt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string objectJSON { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tags tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool confirmedUplink { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string devAddr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string publishedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceProfileID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceProfileName { get; set; }
    }


}
