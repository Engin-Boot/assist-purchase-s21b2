using AlertToCareFrontend.Command;
using AssistToPurchase.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            AddCallSetupRequestCommand = new DelegateCommandClass(this.AddCallSetupRequestCommandWrapper, this.CommandCanExecuteWrapper);
            ClearCallSetupRequestCommand = new DelegateCommandClass(this.ClearCallSetupRequestCommandWrapper, this.CommandCanExecuteWrapper);
        }

        #endregion


        #region Fields
        //private readonly ObservableCollection<ModelsSpecification> _models;
        private SearchQuery searchQuery;
        private  string _name;
        private  string _email;
        private  string _organisation;
        private  string _model;
        private string _region;

        #endregion

        #region Properties


        public string Name
        {
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Model
        {
            get { return this._model; }
            set
            {
                if (value != _model)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Region
        {
            get { return this._region; }
            set
            {
                if (value != _region)
                {
                    _region = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Organisation
        {
            set
            {
                if (value != _organisation)
                {
                    _organisation = value;
                    OnPropertyChanged();
                }
            }
        }

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

        #region Logic
        private void PlaceOrder()
        {
            _client = new RestClient("http://localhost:5000/api/");
            _request = new RestRequest("CallSetupRequest", Method.POST);
            var selectedModels = new List<string>();
            selectedModels.Add(_model);
            _request.AddJsonBody(new CallSetupRequest { CoustomerName = _name,
                RequestId = GenerateRequestId(),
                Email = _email,
                Organisation = _organisation,
                Region = _region,
                SelectedModels = selectedModels }
                );
            _response = _client.Execute(_request);
        }

        private string GenerateRequestId()
        {
            Random random = new Random();
            return $"REQ{random.Next(100, 10000)}";
        }
        #endregion

        #region Commands
        public ICommand AddCallSetupRequestCommand { get; set; }
        public ICommand ClearCallSetupRequestCommand { get; set; }
        #endregion
        #region Command Helper Methods
        void AddCallSetupRequestCommandWrapper(object parameter)
        {
            this.PlaceOrder();
        }

        

        bool CommandCanExecuteWrapper(object parameter)
        {
            return true;
        }

        void ClearCallSetupRequestCommandWrapper(object parameter)
        { 
            //this.ClearSaleRepresentative(); 
        }
        #endregion
    }
}
