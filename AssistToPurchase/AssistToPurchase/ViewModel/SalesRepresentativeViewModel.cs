using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlertToCareFrontend.Command;
using AssistToPurchase.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace AssistToPurchase.ViewModel
{
    class SalesRepresentativeViewModel:BaseViewModel
    {
        public string _baseUrl = "http://localhost:5000/api/";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;

        #region Fields
        SalesRepresentative _salesRepresentativeModel;
        string message;
        private ObservableCollection<SalesRepresentative> _SalesRepresentativesList = new ObservableCollection<SalesRepresentative>();
        #endregion

        #region Initializers

        public SalesRepresentativeViewModel()
        {
            _salesRepresentativeModel = new SalesRepresentative();
            //this._SalesRepresentativesList = SalesRepresentativesList;
            AddSaleRepCommand = new DelegateCommandClass(this.AddSaleRepCommandWrapper,this.CommandCanExecuteWrapper);
        }
        #endregion

        #region Property
        public string Id 
        {
            get { return _salesRepresentativeModel.Id; }
            set
            {
                if(value!=_salesRepresentativeModel.Id)
                {
                    _salesRepresentativeModel.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _salesRepresentativeModel.Name; }
            set
            {
                if (value != _salesRepresentativeModel.Name)
                {
                    _salesRepresentativeModel.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DepartmentRegion
        {
            get { return _salesRepresentativeModel.DepartmentRegion; }
            set
            {
                if (value != _salesRepresentativeModel.DepartmentRegion)
                {
                    _salesRepresentativeModel.DepartmentRegion = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get { return _salesRepresentativeModel.Email; }
            set
            {
                if (value != _salesRepresentativeModel.Email)
                {
                    _salesRepresentativeModel.Email = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<SalesRepresentative> SalesRepresentativesList
        {
            get { return GetSalesRepresentatives(); }
            //set { this._SalesRepresentativesList = value; }
        }

        public string Message 
        { 
            get { return message; }
            set { 
                if(value!=message)
                {
                    message = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Logic

        private void AddNewSalesRepresentative()
        {
            SalesRepresentative newSaleRep = new SalesRepresentative();

            SalesRepresentative savedSaleRep = PostSaleRep(newSaleRep).Result;

            //update settings
            Properties.Settings.Default.CurrentSaleRepId = savedSaleRep.Id;
            Properties.Settings.Default.Save();

            //message 
            Message = String.IsNullOrEmpty(savedSaleRep.Id) ? "Adding Sale Rep Failed" : "Adding Sale Rep Passed";
        }

        //post task
        public static async Task<SalesRepresentative> PostSaleRep(SalesRepresentative reqObj)
        {
            //init
            SalesRepresentative resObj = new SalesRepresentative();

            try
            {
                using(var client=new HttpClient())
                {
                    //base address
                    client.BaseAddress = new Uri("http://localhost:5000/");

                    //content type needed
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); ;

                    //stateess manner
                    client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                    //init resp message
                    HttpResponseMessage response = new HttpResponseMessage();

                    //POST 
                    response = await client.PostAsJsonAsync("api/SaleRepresentative/", reqObj).ConfigureAwait(false);

                    //vertification
                    if(response.IsSuccessStatusCode)
                    {
                        //reading resp
                        string result = response.Content.ReadAsStringAsync().Result;
                        //convert back
                        resObj = JsonConvert.DeserializeObject<SalesRepresentative>(result);
                        //releasing
                        response.Dispose();
                    }
                    else
                    {
                        //reading resp
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return resObj;
        }

        public ObservableCollection<SalesRepresentative> GetSalesRepresentatives()
        {
            //System.Net.WebClient _httpRequest = new System.Net.WebClient();
            //System.Net.HttpWebRequest _httpReq =
            //    System.Net.WebRequest.CreateHttp("http://localhost:5000/api/SalesRepresentative");
            //_httpReq.Method = "GET";
            //System.Net.HttpWebResponse response = _httpReq.GetResponse() as System.Net.HttpWebResponse;
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    Console.WriteLine("Communication Successful");
            //    Console.WriteLine(response.ContentType);
            //    Console.WriteLine(response.ContentLength);
            //    System.Runtime.Serialization.Json.DataContractJsonSerializer _jsonSerializer =
            //        new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<SalesRepresentative>));
            //    List<SalesRepresentative> salesRepresentatives =
            //          _jsonSerializer.ReadObject(response.GetResponseStream()) as List<SalesRepresentative>;
            //    foreach (var salesRepresentative in salesRepresentatives)
            //    {
            //        Console.WriteLine($"SalesRepresentative {salesRepresentative.Id == null} and {salesRepresentative.Name == null}");
            //    }
            //    return new ObservableCollection<SalesRepresentative>(salesRepresentatives); ;
            //}
            //return new ObservableCollection<SalesRepresentative>();

            _client = new RestClient(_baseUrl);
            _request = new RestRequest("SalesRepresentative", Method.GET);
            

            _response = _client.Execute(_request);
            var salesRepresentatives = _deserializer.Deserialize<List<SalesRepresentative>>(_response);
            foreach (var salesRepresentative in salesRepresentatives)
            {
                Console.WriteLine($"SalesRepresentative {salesRepresentative.Id == null} and {salesRepresentative.Name == null}");
            }
            return new ObservableCollection<SalesRepresentative>(salesRepresentatives);
        }

        #endregion

        #region Commands
        public ICommand AddSaleRepCommand { get; set; }
        #endregion

        #region Command Helper Methods
        void AddSaleRepCommandWrapper(object parameter)
        {
            this.AddNewSalesRepresentative();
        }
        bool CommandCanExecuteWrapper(object parameter)
        {
            return true;
        }
        #endregion
    }
}
