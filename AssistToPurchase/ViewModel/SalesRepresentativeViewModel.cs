﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AlertToCareFrontend.Command;
using AssistToPurchase.Model;

using RestSharp;
using RestSharp.Serialization.Json;

namespace AssistToPurchase.ViewModel
{
    class SalesRepresentativeViewModel : BaseViewModel
    {
        public string _baseUrl = "http://localhost:5000/api/";
        private static RestClient _client;
        private static RestRequest _request;
        private readonly JsonDeserializer _deserializer = new JsonDeserializer();
        private static IRestResponse _response;

        #region Fields
        readonly SalesRepresentative _salesRepresentativeModel;
        string message;
        string _requestId;
        string _salesRepresentativeId;
        string _salesRepName;
        #endregion

        #region Initializers

        public SalesRepresentativeViewModel()
        {
            _salesRepresentativeModel = new SalesRepresentative();
            UpdateSalesRepresentativeList();
            UpdatePendingRequestList();
            AddSaleRepCommand = new DelegateCommandClass(this.AddSaleRepCommandWrapper, this.CommandCanExecuteWrapper);
            UpdateSaleRepCommand = new DelegateCommandClass(this.UpdateSaleRepCommandWrapper, this.CommandCanExecuteWrapper);
            ClearSaleRepCommand = new DelegateCommandClass(this.ClearSaleRepCommandWrapper, this.CommandCanExecuteWrapper);
            AcceptOrderCommand = new DelegateCommandClass(this.AcceptOrderCommandWrapper, this.CommandCanExecuteWrapper);
        }
        #endregion

        #region Property
        public string Id
        {
            get { return _salesRepresentativeModel.Id; }
            set
            {
                if (value != _salesRepresentativeModel.Id)
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
        public string SalesRepName
        {
            get { return this._salesRepName; }
            set
            {
                if (value != _salesRepName)
                {
                    this._salesRepName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RequestId
        {
            get { return this._requestId; }
            set
            {
                if (value != _requestId)
                {
                    _requestId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SalesRepresentativeId
        {
            get { return this._salesRepresentativeId; }
            set
            {
                if (value != _salesRepresentativeId)
                {
                    _salesRepresentativeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<SalesRepresentative> SalesRepresentativesList { get; set; } = new ObservableCollection<SalesRepresentative>();

        public ObservableCollection<CallSetupRequest> PendingRequestsList { get; set; } = new ObservableCollection<CallSetupRequest>();

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

        public void AddNewSalesRepresentative()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("SalesRepresentative", Method.POST);
                _request.AddJsonBody(new SalesRepresentative { Id = Id, Name = Name, DepartmentRegion = DepartmentRegion, Email = Email });
                _response = _client.Execute(_request);
                var message = _response.Content;
                MessageBox.Show($"{message}");
                UpdateSalesRepresentativeList();
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }


        }

        public void UpdateSalesRepresentative()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("SalesRepresentative", Method.PUT);
                _request.AddJsonBody(new SalesRepresentative { Id = Id, Name = Name, DepartmentRegion = DepartmentRegion, Email = Email });
                _response = _client.Execute(_request);
                var message = _response.Content;
                MessageBox.Show($"{message}");
                UpdateSalesRepresentativeList();

            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }

        }

        public void AcceptOrder()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest($"CallSetupRequest/{RequestId}/{SalesRepresentativeId}", Method.DELETE);
                _response = _client.Execute(_request);
                var message = _response.Content;
                MessageBox.Show($"{message}");
                UpdatePendingRequestList();
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }

        public void ClearSaleRepresentative()
        {
            this.Id = "";
            this.Name = "";
            this.DepartmentRegion = "";
            this.Email = "";
        }



        //private void AddNewSalesRepresentative()
        //{
        //    SalesRepresentative newSaleRep = new SalesRepresentative();

        //    SalesRepresentative savedSaleRep = PostSaleRep(newSaleRep).Result;

        //    //update settings
        //    Properties.Settings.Default.CurrentSaleRepId = savedSaleRep.Id;
        //    Properties.Settings.Default.Save();

        //    //message 
        //    Message = String.IsNullOrEmpty(savedSaleRep.Id) ? "Adding Sale Rep Failed" : "Adding Sale Rep Passed";
        //}

        ////post task
        //public static async Task<SalesRepresentative> PostSaleRep(SalesRepresentative reqObj)
        //{
        //    //init
        //    SalesRepresentative resObj = new SalesRepresentative();

        //    try
        //    {
        //        using(var client=new HttpClient())
        //        {
        //            //base address
        //            client.BaseAddress = new Uri("http://localhost:5000/");

        //            //content type needed
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); ;

        //            //stateess manner
        //            client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

        //            //init resp message
        //            HttpResponseMessage response = new HttpResponseMessage();

        //            //POST 
        //            response = await client.PostAsJsonAsync("api/SaleRepresentative/", reqObj).ConfigureAwait(false);

        //            //vertification
        //            if(response.IsSuccessStatusCode)
        //            {
        //                //reading resp
        //                string result = response.Content.ReadAsStringAsync().Result;
        //                //convert back
        //                resObj = JsonConvert.DeserializeObject<SalesRepresentative>(result);
        //                //releasing
        //                response.Dispose();
        //            }
        //            else
        //            {
        //                //reading resp
        //                string result = response.Content.ReadAsStringAsync().Result;
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return resObj;
        //}

        public void UpdateSalesRepresentativeList()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("SalesRepresentative", Method.GET);


                _response = _client.Execute(_request);
                var salesRepresentatives = _deserializer.Deserialize<List<SalesRepresentative>>(_response);
                SalesRepresentativesList.Clear();
                foreach (var salesRepresentative in salesRepresentatives)
                {
                    SalesRepresentativesList.Add(salesRepresentative);
                    //if (!CheckWhetherSalesRepresentativeExists(salesRepresentative.Id))  // can remove safely
                    //{
                    //    SalesRepresentativesList.Add(salesRepresentative);
                    //}
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }

        public void UpdatePendingRequestList()
        {
            try
            {
                _client = new RestClient(_baseUrl);
                _request = new RestRequest("CallSetupRequest", Method.GET);


                _response = _client.Execute(_request);
                var callSetupRequests = _deserializer.Deserialize<List<CallSetupRequest>>(_response);
                PendingRequestsList.Clear();
                foreach (var callSetupRequest in callSetupRequests)
                {
                    PendingRequestsList.Add(callSetupRequest);
                    //if (!CheckWhetherCallRequestExists(callSetupRequest.RequestId))  // can remove safely
                    //{
                    //    PendingRequestsList.Add(callSetupRequest);
                    //}
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Server Down: Unable to connect to Server");
            }
        }

        public bool CheckWhetherSalesRepresentativeExists(string id)
        {
            var s = SalesRepresentativesList.Where(x => x.Id == id);
            if (s.Count() != 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckWhetherCallRequestExists(string id)
        {
            var s = PendingRequestsList.Where(x => x.RequestId == id);
            if (s.Count() != 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Commands
        public ICommand AddSaleRepCommand { get; set; }
        public ICommand UpdateSaleRepCommand { get; set; }
        public ICommand AcceptOrderCommand { get; set; }
        public ICommand ClearSaleRepCommand { get; set; }
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

        void AcceptOrderCommandWrapper(object parameter)
        {
            this.AcceptOrder();
        }
        void UpdateSaleRepCommandWrapper(object parameter)
        {
            this.AddNewSalesRepresentative();
        }

        void ClearSaleRepCommandWrapper(object parameter)
        { this.ClearSaleRepresentative(); }
        #endregion
    }
}
