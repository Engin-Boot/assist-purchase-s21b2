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
            UpdateModelsList();

        }

        #endregion


        #region Fields
        //private readonly ObservableCollection<ModelsSpecification> _models;
        private SearchQuery searchQuery;

        #endregion

        #region Properties
        public ObservableCollection<ModelsSpecification> Models { get; set; } = new ObservableCollection<ModelsSpecification>();

        public string Id 
        { 
            set 
            {
                if (value != searchQuery.Id)
                {
                    searchQuery.Id = value;
                    OnPropertyChanged();
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
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
                    UpdateModelsList();
                }
            }
        }
        #endregion


        #region Methods Getting Data From Database

        public void UpdateModelsList()
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
            Models.Clear();
            foreach (var model in models)
            {
                if (!CheckWhetherModelExists(model.Id))
                {
                    Models.Add(model);
                }
            }
            
        }
        public bool CheckWhetherModelExists(long id)
        {
            var s = Models.Where(x => x.Id == id);
            if (s.Count() != 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
