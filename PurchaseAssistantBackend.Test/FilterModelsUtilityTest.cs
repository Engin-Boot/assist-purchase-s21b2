using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Utilities;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class FilterModelsUtilityTest
    {
        private readonly List<ModelsSpecification> _models;
        public FilterModelsUtilityTest()
        {
            _models = new List<ModelsSpecification> {
                new ModelsSpecification
                {
                    Id = 1,
                    ProductName = "IntelliVue",
                    ProductKey = "X3",
                    Description =
                        "The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
                    Price = "14500",
                    Weight = 65,
                    Portable = true,
                    ScreenSize = 6.1,
                    TouchScreenSupport = true,
                    MonitorResolution = "10*11",
                    BatterySupport = "NO",
                    MultiPatientSupport = "NO",
                    BpCheck = "YES",
                    HeartRateCheck = "NO",
                    EcgCheck = "YES",
                    SpO2Check = "YES",
                    TemperatureCheck = "YES",
                    CardiacOutputCheck = "YES"
                },
                new ModelsSpecification
                {
                    Id = 2,
                    ProductName = "Intelli",
                    ProductKey = "MX40",
                    Description =
                        "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                    Price = "37000",
                    Weight = 65,
                    Portable = true,
                    ScreenSize = 2.8,
                    TouchScreenSupport = true,
                    MonitorResolution = "10*15",
                    BatterySupport = "YES",
                    MultiPatientSupport = "NO",
                    BpCheck = "YES",
                    HeartRateCheck = "YES",
                    EcgCheck = "NO",
                    SpO2Check = "YES",
                    TemperatureCheck = "YES",
                    CardiacOutputCheck = "NO"
                }
            };
        }

        [AssertionMethod]
        private void TestModelInfoWithFirstModel(ModelsSpecification model)
        {
            Assert.Equal("IntelliVue", model.ProductName);
            Assert.Equal("X3", model.ProductKey);
            Assert.Equal("The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.", model.Description);
            Assert.Equal("14500", model.Price);
            Assert.Equal(65, model.Weight);
            Assert.True(model.Portable);
            Assert.Equal(6.1, model.ScreenSize);
            Assert.True(model.TouchScreenSupport);
            Assert.Equal("10*11", model.MonitorResolution);
            Assert.Equal("NO", model.BatterySupport);
            Assert.Equal("NO", model.MultiPatientSupport);
            Assert.Equal("YES", model.BpCheck);
            Assert.Equal("NO", model.HeartRateCheck);
            Assert.Equal("YES", model.EcgCheck);
            Assert.Equal("YES", model.SpO2Check);
            Assert.Equal("YES", model.TemperatureCheck);
            Assert.Equal("YES", model.CardiacOutputCheck);
        }

        [AssertionMethod]
        private void TestModelInfoWithSecondModel(ModelsSpecification secondModel)
        {
            Assert.Equal("Intelli", secondModel.ProductName);
            Assert.Equal("MX40", secondModel.ProductKey);
            Assert.Equal("The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                secondModel.Description);
            Assert.Equal("37000", secondModel.Price);
            Assert.Equal(65, secondModel.Weight);
            Assert.True(secondModel.Portable);
            Assert.Equal(2.8, secondModel.ScreenSize);
            Assert.True(secondModel.TouchScreenSupport);
            Assert.Equal("10*15", secondModel.MonitorResolution);
            Assert.Equal("YES", secondModel.BatterySupport);
            Assert.Equal("NO", secondModel.MultiPatientSupport);
            Assert.Equal("YES", secondModel.BpCheck);
            Assert.Equal("YES", secondModel.HeartRateCheck);
            Assert.Equal("YES", secondModel.SpO2Check);
            Assert.Equal("YES", secondModel.TemperatureCheck);
            Assert.Equal("NO", secondModel.CardiacOutputCheck);
            Assert.Equal("NO", secondModel.EcgCheck);
        }

        [Fact]
        public void WhenApplyFilterByIdWithNullOrEmptyIdThenReturnAllModels()
        {
            var filteredModelsById = FilterModelsUtility.FilterById("", _models);
            Assert.Equal(2, filteredModelsById.Count());

            filteredModelsById = FilterModelsUtility.FilterById(null, _models);
            Assert.Equal(2, filteredModelsById.Count());
        }

        [Fact]
        public void WhenApplyFilterByIdWithNonIntegerIdThenThrowException()
        {
            try
            {
                _ = FilterModelsUtility.FilterById("abc", _models);
            }
            catch(ArgumentException exception)
            {
                Assert.Equal("Query Argument 'id' is invalid. Id must be a long number.", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByIdWithValidIdThenReturnModelsWithMatchingId()
        {
            var filteredModelsById = FilterModelsUtility.FilterById("1", _models).ToList();
            Assert.Single(filteredModelsById);

            var model = filteredModelsById[0];
            TestModelInfoWithFirstModel(model);
        }

        [Fact]
        public void WhenApplyFilterByProductNameWithNullOrEmptyProductNameValueThenReturnAllModels()
        {
            var filteredModelsByProductName = FilterModelsUtility.FilterByProductName("", _models);
            Assert.Equal(2, filteredModelsByProductName.Count());

            filteredModelsByProductName = FilterModelsUtility.FilterByProductName(null, _models);
            Assert.Equal(2, filteredModelsByProductName.Count());
        }

        [Fact]
        public void WhenApplyFilterByProductNameWithValidProductNameThenReturnModelsWithMatchingProductName()
        {
            var filteredModelsByProductName = FilterModelsUtility.FilterByProductName("IntelliVue", _models).ToList();
            Assert.Single(filteredModelsByProductName);

            var model = filteredModelsByProductName[0];
            TestModelInfoWithFirstModel(model);
        }

        [Fact]
        public void WhenApplyFilterByProductKeyWithNullOrEmptyProductKeyValueThenReturnAllModels()
        {
            var filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey("", _models);
            Assert.Equal(2, filteredModelsByProductKey.Count());

            filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey(null, _models);
            Assert.Equal(2, filteredModelsByProductKey.Count());
        }

        [Fact]
        public void WhenApplyFilterByProductKeyWithValidProductKeyThenReturnModelsWithMatchingProductKey()
        {
            var filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey("X3", _models).ToList();
            Assert.Single(filteredModelsByProductKey);

            var model = filteredModelsByProductKey[0];
            TestModelInfoWithFirstModel(model);
        }

        [Fact]
        public void WhenApplyFilterByPortabilityWithNullOrEmptyPortabilityThenReturnAllModels()
        {
            var filteredModelsByPortability = FilterModelsUtility.FilterByPortability("", _models);
            Assert.Equal(2, filteredModelsByPortability.Count());

            filteredModelsByPortability = FilterModelsUtility.FilterByPortability(null, _models);
            Assert.Equal(2, filteredModelsByPortability.Count());
        }

        [Fact]
        public void WhenApplyFilterByPortabilityWithNonBooleanValueThenThrowException()
        {
            try
            {
                _ = FilterModelsUtility.FilterByPortability("required", _models);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("Query Argument 'portability' is invalid. It must be a boolean value (either true or false).", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByPortabilityWithValidBooleanValueThenReturnModelsWithMatchingPortability()
        {
            var filteredModelsByPortability = FilterModelsUtility.FilterByPortability("true", _models).ToList();
            Assert.Equal(2, filteredModelsByPortability.Count);

            TestModelInfoWithFirstModel(filteredModelsByPortability[0]);
            TestModelInfoWithSecondModel(filteredModelsByPortability[1]);
        }
        [Fact]
        public void WhenApplyFilterByBatterySupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport("", _models);
            Assert.Equal(2, filteredModelsByBatterySupport.Count());

            filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport(null, _models);
            Assert.Equal(2, filteredModelsByBatterySupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByBatterySupportWithValidValueThenReturnModelsWithMatchingBatterySupport()
        {
            var filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport("YES", _models).ToList();
            Assert.Single(filteredModelsByBatterySupport);

            TestModelInfoWithSecondModel(filteredModelsByBatterySupport[0]);
        }

        [Fact]
        public void WhenApplyFilterByMultiPatientSupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport("", _models);
            Assert.Equal(2, filteredModelsByMultiPatientSupport.Count());

            filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport(null, _models);
            Assert.Equal(2, filteredModelsByMultiPatientSupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByMultiPatientSupportWithValidValueThenReturnModelsWithMatchingMultiPatientSupport()
        {
            var filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport("YES", _models);
            Assert.Empty(filteredModelsByMultiPatientSupport);
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport("", _models);
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count());

            filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport(null, _models);
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithNonBooleanValueThenThrowException()
        {
            try
            {
                _ = FilterModelsUtility.FilterByTouchScreenSupport("required", _models);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("Query Argument 'touchScreenSupport' is invalid. It must be a valid boolean value (either true or false).", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithValidBooleanValueThenReturnModelsWithMatchingTouchScreenSupportValue()
        {
            var filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport("true", _models).ToList();
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count);

            TestModelInfoWithFirstModel(filteredModelsByTouchScreenSupport[0]);
            TestModelInfoWithSecondModel(filteredModelsByTouchScreenSupport[1]);
        }


        [Fact]
        public void WhenApplyFilterByBpCheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByBpCheck = FilterModelsUtility.FilterByBpCheck("", _models);
            Assert.Equal(2, filteredModelsByBpCheck.Count());

            filteredModelsByBpCheck = FilterModelsUtility.FilterByBpCheck(null, _models);
            Assert.Equal(2, filteredModelsByBpCheck.Count());
        }

        [Fact]
        public void WhenApplyFilterByBpCheckWithValidValueThenReturnModelsWithMatchingBpCheckSupport()
        {
            var filteredModelsByBpCheck = FilterModelsUtility.FilterByBpCheck("NO", _models);
            Assert.Empty(filteredModelsByBpCheck);
        }


        [Fact]
        public void WhenApplyFilterByHeartRateCheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByHeartRateCheck = FilterModelsUtility.FilterByHeartRateCheck("", _models);
            Assert.Equal(2, filteredModelsByHeartRateCheck.Count());

            filteredModelsByHeartRateCheck = FilterModelsUtility.FilterByHeartRateCheck(null, _models);
            Assert.Equal(2, filteredModelsByHeartRateCheck.Count());
        }

        [Fact]
        public void WhenApplyFilterByHeartRateCheckWithValidValueThenReturnModelsWithMatchingHeartRateCheckSupport()
        {
            var filteredModelsByHeartRateCheck = FilterModelsUtility.FilterByHeartRateCheck("YES", _models);
            Assert.Single(filteredModelsByHeartRateCheck);
        }


        [Fact]
        public void WhenApplyFilterByEcgCheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByEcgCheck = FilterModelsUtility.FilterByEcgCheck("", _models);
            Assert.Equal(2, filteredModelsByEcgCheck.Count());

            filteredModelsByEcgCheck = FilterModelsUtility.FilterByEcgCheck(null, _models);
            Assert.Equal(2, filteredModelsByEcgCheck.Count());
        }

        [Fact]
        public void WhenApplyFilterByEcgCheckWithValidValueThenReturnModelsWithMatchingEcgCheckSupport()
        {
            var filteredModelsByEcgCheck = FilterModelsUtility.FilterByEcgCheck("YES", _models);
            Assert.Single(filteredModelsByEcgCheck);
        }


        [Fact]
        public void WhenApplyFilterBySpO2CheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsBySpO2Check = FilterModelsUtility.FilterBySpO2Check("", _models);
            Assert.Equal(2, filteredModelsBySpO2Check.Count());

            filteredModelsBySpO2Check = FilterModelsUtility.FilterBySpO2Check(null, _models);
            Assert.Equal(2, filteredModelsBySpO2Check.Count());
        }

        [Fact]
        public void WhenApplyFilterBySpO2CheckWithValidValueThenReturnModelsWithMatchingSpO2CheckSupport()
        {
            var filteredModelsBySpO2Check = FilterModelsUtility.FilterBySpO2Check("YES", _models);
            Assert.Equal(2, filteredModelsBySpO2Check.Count());
        }


        [Fact]
        public void WhenApplyFilterByTemperatureCheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByTemperatureCheck = FilterModelsUtility.FilterByTemperatureCheck("", _models);
            Assert.Equal(2, filteredModelsByTemperatureCheck.Count());

            filteredModelsByTemperatureCheck = FilterModelsUtility.FilterByTemperatureCheck(null, _models);
            Assert.Equal(2, filteredModelsByTemperatureCheck.Count());
        }

        [Fact]
        public void WhenApplyFilterByTemperatureCheckWithValidValueThenReturnModelsWithMatchingTemperatureCheckSupport()
        {
            var filteredModelsByTemperatureCheck = FilterModelsUtility.FilterByTemperatureCheck("YES", _models);
            Assert.Equal(2, filteredModelsByTemperatureCheck.Count());
        }

        
        [Fact]
        public void WhenApplyFilterByCardiacOutputCheckWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByCardiacOutputCheck = FilterModelsUtility.FilterByCardiacOutputCheck("", _models);
            Assert.Equal(2, filteredModelsByCardiacOutputCheck.Count());

            filteredModelsByCardiacOutputCheck = FilterModelsUtility.FilterByCardiacOutputCheck(null, _models);
            Assert.Equal(2, filteredModelsByCardiacOutputCheck.Count());
        }

        [Fact]
        public void WhenApplyFilterByCardiacOutputCheckWithValidValueThenReturnModelsWithMatchingCardiacOutputCheckSupport()
        {
            var filteredModelsByCardiacOutputCheck = FilterModelsUtility.FilterByCardiacOutputCheck("YES", _models);
            Assert.Single(filteredModelsByCardiacOutputCheck);
        }


        [Fact]
        public void WhenApplyAllFiltersThenReturnFilteredModelsResult()
        {
            SearchQuery query = new SearchQuery { BpCheck = "YES", SpO2Check = "YES", HeartRateCheck = "YES", TemperatureCheck = "YES", CardiacOutputCheck = "NO", EcgCheck = "NO", 
                Portability = "true", BatterySupport = "YES", MultiPatientSupport="NO", TouchScreenSupport="true"};
            var filteredModelsList = FilterModelsUtility.ApplyAllFilters(_models, query).ToList();
            
            Assert.Single(filteredModelsList);

            TestModelInfoWithSecondModel(filteredModelsList[0]);

            query = new SearchQuery { ProductName = "IntelliVue", ProductKey = "X3" };
            filteredModelsList = FilterModelsUtility.ApplyAllFilters(_models, query).ToList();
            Assert.Single(filteredModelsList);

            query = new SearchQuery { Id = "1" };
            filteredModelsList = FilterModelsUtility.ApplyAllFilters(_models, query).ToList();
            Assert.Single(filteredModelsList);
        }
    }
}
