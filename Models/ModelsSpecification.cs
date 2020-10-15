namespace AssistPurchase.Models
{
    public class ModelsSpecification
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductKey { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public double Weight { get; set; }
        public bool Portable { get; set; }
        public double ScreenSize { get; set; }
        public bool TouchScreenSupport { get; set; }
        public string MonitorResolution { get; set; }
        public string BatterySupport { get; set; }
        public string MultiPatientSupport { get; set; }
    }
}
