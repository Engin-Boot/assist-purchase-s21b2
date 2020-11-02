using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AlertToCareFrontend.Command;
using AssistToPurchase.Model;
using RestSharp;
using RestSharp.Serialization.Json;

namespace AssistToPurchase.ViewModel
{
    class ModelCatalogViewModel : BaseViewModel
    {
        public string _baseUrl = "http://localhost:5000/api/";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;

        #region Fields
        readonly ModelsSpecification _modelsSpecification;
        long _modelIdToDelete;
        string message;

        #endregion

        #region Initialzers

        public ModelCatalogViewModel()
        {
            _modelsSpecification = new ModelsSpecification();
            UpdateModelList();//list 
            AddModelCommand = new DelegateCommandClass(this.AddModelCommandWrapper, this.CommandCanExecuteWrapper);
            ClearModelCommand = new DelegateCommandClass(this.ClearModelCommandWrapper, this.CommandCanExecuteWrapper);
            DeleteModelCommand = new DelegateCommandClass(this.DeleteModelCommandWrapper, this.CommandCanExecuteWrapper);
        }
        #endregion

        #region Property
        public long ModelIdToDelete
        {
            get { return _modelIdToDelete; }
            set
            {
                if (value != _modelIdToDelete)
                {
                    _modelIdToDelete = value;
                    OnPropertyChanged();
                }
            }
        }
        public long Id
        {
            get { return _modelsSpecification.Id; }
            set
            {
                if (value != _modelsSpecification.Id)
                {
                    _modelsSpecification.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ProductName
        {
            get { return _modelsSpecification.ProductName; }
            set
            {
                if (value != _modelsSpecification.ProductName)
                {
                    _modelsSpecification.ProductName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ProductKey
        {
            get { return _modelsSpecification.ProductKey; }
            set
            {
                if (value != _modelsSpecification.ProductKey)
                {
                    _modelsSpecification.ProductKey = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get { return _modelsSpecification.Description; }
            set
            {
                if (value != _modelsSpecification.Description)
                {
                    _modelsSpecification.Description = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Price
        {
            get { return _modelsSpecification.Price; }
            set
            {
                if (value != _modelsSpecification.Price)
                {
                    _modelsSpecification.Price = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Weight
        {
            get { return _modelsSpecification.Weight; }
            set
            {
                if (value != _modelsSpecification.Weight)
                {
                    _modelsSpecification.Weight = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Portable
        {
            get { return _modelsSpecification.Portable; }
            set
            {
                if (value != _modelsSpecification.Portable)
                {
                    _modelsSpecification.Portable = value;
                    OnPropertyChanged();
                }
            }
        }
        public double ScreenSize
        {
            get { return _modelsSpecification.ScreenSize; }
            set
            {
                if (value != _modelsSpecification.ScreenSize)
                {
                    _modelsSpecification.ScreenSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool TouchScreenSupport
        {
            get { return _modelsSpecification.TouchScreenSupport; }
            set
            {
                if (value != _modelsSpecification.TouchScreenSupport)
                {
                    _modelsSpecification.TouchScreenSupport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MonitorResolution
        {
            get { return _modelsSpecification.MonitorResolution; }
            set
            {
                if (value != _modelsSpecification.MonitorResolution)
                {
                    _modelsSpecification.MonitorResolution = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BatterySupport
        {
            get { return _modelsSpecification.BatterySupport; }
            set
            {
                if (value != _modelsSpecification.BatterySupport)
                {
                    _modelsSpecification.BatterySupport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MultiPatientSupport
        {
            get { return _modelsSpecification.MultiPatientSupport; }
            set
            {
                if (value != _modelsSpecification.MultiPatientSupport)
                {
                    _modelsSpecification.MultiPatientSupport = value;
                    OnPropertyChanged();
                }
            }
        }
        // clinical parameters
        public string BpCheck
        {
            get { return _modelsSpecification.BpCheck; }
            set
            {
                if (value != _modelsSpecification.BpCheck)
                {
                    _modelsSpecification.BpCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HeartRateCheck
        {
            get { return _modelsSpecification.HeartRateCheck; }
            set
            {
                if (value != _modelsSpecification.HeartRateCheck)
                {
                    _modelsSpecification.HeartRateCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EcgCheck
        {
            get { return _modelsSpecification.EcgCheck; }
            set
            {
                if (value != _modelsSpecification.EcgCheck)
                {
                    _modelsSpecification.EcgCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SpO2Check
        {
            get { return _modelsSpecification.SpO2Check; }
            set
            {
                if (value != _modelsSpecification.SpO2Check)
                {
                    _modelsSpecification.SpO2Check = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TemperatureCheck
        {
            get { return _modelsSpecification.TemperatureCheck; }
            set
            {
                if (value != _modelsSpecification.TemperatureCheck)
                {
                    _modelsSpecification.TemperatureCheck = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CardiacOutputCheck
        {
            get { return _modelsSpecification.CardiacOutputCheck; }
            set
            {
                if (value != _modelsSpecification.CardiacOutputCheck)
                {
                    _modelsSpecification.CardiacOutputCheck = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ModelsSpecification> ModelsSpecificationsList { get; set; } = new ObservableCollection<ModelsSpecification>();

        public string Message
        {
            get { return message; }
            set
            {
                if (value != message)
                {
                    message = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Logic

        public void AddNewModel()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("ModelsSpecification", Method.POST);
                _request.AddJsonBody(new ModelsSpecification
                {
                    Id = Id,
                    ProductName = ProductName,
                    ProductKey = ProductKey,
                    Description = Description,
                    Price = Price,
                    Weight = Weight,
                    Portable = Portable,
                    ScreenSize = ScreenSize,
                    TouchScreenSupport = TouchScreenSupport,
                    MonitorResolution = MonitorResolution,
                    BatterySupport = BatterySupport,
                    MultiPatientSupport = MultiPatientSupport,

                    BpCheck = BpCheck,
                    HeartRateCheck = HeartRateCheck,
                    EcgCheck = EcgCheck,
                    SpO2Check = SpO2Check,
                    TemperatureCheck = TemperatureCheck,
                    CardiacOutputCheck = CardiacOutputCheck



                });

                _response = _client.Execute(_request);
                var message = _response.Content;
                MessageBox.Show($"{message}");
                ClearModel();
                UpdateModelList();
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }

        public void ClearModel()
        {
            this.Id = 0;
            this.ProductName = "";
            this.ProductKey = "";
            this.Description = "";
            this.Price = "";
            this.Weight = 0;
            this.Portable = false;
            this.ScreenSize = 0;
            this.TouchScreenSupport = false;
            this.MonitorResolution = "";
            this.BatterySupport = "";
            this.MultiPatientSupport = "";

            this.BpCheck = "";
            this.HeartRateCheck = "";
            this.EcgCheck = "";
            this.SpO2Check = "";
            this.TemperatureCheck = "";
            this.CardiacOutputCheck = "";
        }

        public void UpdateModelList()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("ModelsSpecification", Method.GET);

                _response = _client.Execute(_request);

                var models = _deserializer.Deserialize<List<ModelsSpecification>>(_response);
                ModelsSpecificationsList.Clear();
                foreach (var model in models)
                {
                    ModelsSpecificationsList.Add(model);
                    //if (!CheckWhetherModelExist(model.Id))
                    //{
                    //    ModelsSpecificationsList.Add(model);
                    //}
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }

        public bool CheckWhetherModelExist(long id)
        {
            var model = ModelsSpecificationsList.Where(x => x.Id == id);
            if (model.Count() != 0)
            {
                return true;
            }
            return false;
        }

        public void DeleteModel()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest($"ModelsSpecification/{ModelIdToDelete}", Method.DELETE);
                _response = _client.Execute(_request);
                var message = _response.Content;
                MessageBox.Show($"{message}");
                UpdateModelList();
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }
        #endregion

        #region Commands

        public ICommand AddModelCommand { get; set; }

        public ICommand DeleteModelCommand { get; set; }

        public ICommand ClearModelCommand { get; set; }

        #endregion


        #region Command Helper Methods
        void AddModelCommandWrapper(object parameter)
        {
            this.AddNewModel();
        }
        bool CommandCanExecuteWrapper(object parameter)
        {
            return true;
        }
        void DeleteModelCommandWrapper(object parameter)
        {
            this.DeleteModel();
        }
        void ClearModelCommandWrapper(object parameter)
        {
            this.ClearModel();
        }
        #endregion
    }
}
