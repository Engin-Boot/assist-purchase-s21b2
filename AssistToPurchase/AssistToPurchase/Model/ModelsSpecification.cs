using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistToPurchase.Model
{
    class ModelsSpecification
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




        // clinical parameters
        public string BpCheck { get; set; }
        public string HeartRateCheck { get; set; }
        public string EcgCheck { get; set; }
        public string SpO2Check { get; set; }
        public string TemperatureCheck { get; set; }
        public string CardiacOutputCheck { get; set; }
    }
}
