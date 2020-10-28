using AssistToPurchase.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistToPurchase.ViewModel
{
    class ContinuousMonitoringViewModel : BaseViewModel
    {
        public string _baseUrl = "http://localhost:5000/api/ContinuousPatientMonitoringSystems";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;

        #region Constructor

        public ContinuousMonitoringViewModel()
        {
            this.searchQuery = new SearchQuery();
            //this._models = GetModels();

        }

        #endregion


        #region Fields
        //private readonly ObservableCollection<ModelsSpecification> _models;
        private SearchQuery searchQuery;
    
        #endregion

        #region Properties
        public ObservableCollection<ModelsSpecification> Models
        {
            get { return GetModels(); }
        }

        public string Id 
        { 
            set 
            {
                if (value != searchQuery.Id)
                {
                    searchQuery.Id = value;
                    OnPropertyChanged();
                }
            } 
        }
        public string ProductName
        {
            set
            {
                if (value != searchQuery.ProductName)
                {
                    searchQuery.ProductName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ProductKey
        {
            set
            {
                if (value != searchQuery.ProductKey)
                {
                    searchQuery.ProductKey = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Portability
        {
            set
            {
                if (value != searchQuery.Portability)
                {
                    searchQuery.Portability = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BatterySupport
        {
            set
            {
                if (value != searchQuery.BatterySupport)
                {
                    searchQuery.BatterySupport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MultiPatientSupport
        {
            set
            {
                if (value != searchQuery.MultiPatientSupport)
                {
                    searchQuery.MultiPatientSupport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TouchScreenSupport
        {
            set
            {
                if (value != searchQuery.TouchScreenSupport)
                {
                    searchQuery.TouchScreenSupport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BpCheck
        {
            set
            {
                if (value != searchQuery.BpCheck)
                {
                    searchQuery.BpCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HeartRateCheck
        {
            set
            {
                if (value != searchQuery.HeartRateCheck)
                {
                    searchQuery.HeartRateCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EcgCheck
        {
            set
            {
                if (value != searchQuery.EcgCheck)
                {
                    searchQuery.EcgCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SpO2Check
        {
            set
            {
                if (value != searchQuery.SpO2Check)
                {
                    searchQuery.SpO2Check = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TemperatureCheck
        {
            set
            {
                if (value != searchQuery.TemperatureCheck)
                {
                    searchQuery.TemperatureCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CardiacOutputCheck
        {
            set
            {
                if (value != searchQuery.CardiacOutputCheck)
                {
                    searchQuery.CardiacOutputCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region Methods Getting Data From Database

        public ObservableCollection<ModelsSpecification> GetModels()
        {
            _client = new RestClient(_baseUrl);
            string request = $"Id={searchQuery.Id}" +
                $"&ProductName={searchQuery.ProductName}" +
                $"&ProductKey={searchQuery.ProductKey}" +
                $"&Portability={searchQuery.Portability}" +
                $"&BatterySupport={searchQuery.BatterySupport}" +
                $"&MultiPatientSupport={searchQuery.MultiPatientSupport}" +
                $"&TouchScreenSupport={searchQuery.TouchScreenSupport}" +
                $"&BpCheck={searchQuery.BpCheck}" +
                $"&HeartRateCheck={searchQuery.HeartRateCheck}" +
                $"&EcgCheck={searchQuery.EcgCheck}" +
                $"&SpO2Check={searchQuery.SpO2Check}" +
                $"&TemperatureCheck={searchQuery.TemperatureCheck}" +
                $"&CardiacOutputCheck={searchQuery.CardiacOutputCheck}";


            _request = new RestRequest($"?{request}", Method.GET);
            _response = _client.Execute(_request);
            var models = _deserializer.Deserialize<List<ModelsSpecification>>(_response);
            foreach(var model in models)
            {
                Console.WriteLine($"{model.ProductName} and {model.ProductName}");
            }
            return new ObservableCollection<ModelsSpecification>(models);
        }

        #endregion
    }
}
