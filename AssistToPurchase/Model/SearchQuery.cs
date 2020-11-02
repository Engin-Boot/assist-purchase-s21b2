namespace AssistToPurchase.Model
{
    class SearchQuery
    {

        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductKey { get; set; }
        public string Portability { get; set; }
        public string BatterySupport { get; set; }
        public string MultiPatientSupport { get; set; }
        public string TouchScreenSupport { get; set; }

        // clinical parameters
        public string BpCheck { get; set; }
        public string HeartRateCheck { get; set; }
        public string EcgCheck { get; set; }
        public string SpO2Check { get; set; }
        public string TemperatureCheck { get; set; }
        public string CardiacOutputCheck { get; set; }
    }
}
