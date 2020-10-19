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
                    MonitorResolution = "10*11",
                    BatterySupport = "YES",
                    MultiPatientSupport = "NO",

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
        }

        [AssertionMethod]
        private void TestModelInfoWithSecondModel(ModelsSpecification model)
        {
            Assert.Equal("Intelli", model.ProductName);
            Assert.Equal("MX40", model.ProductKey);
            Assert.Equal("The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                model.Description);
            Assert.Equal("37000", model.Price);
            Assert.Equal(65, model.Weight);
            Assert.True(model.Portable);
            Assert.Equal(2.8, model.ScreenSize);
            Assert.True(model.TouchScreenSupport);
            Assert.Equal("10*11", model.MonitorResolution);
            Assert.Equal("YES", model.BatterySupport);
            Assert.Equal("NO", model.MultiPatientSupport);
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
        public void WhenApplyAllFiltersThenReturnFilteredModelsResult()
        {
            SearchQuery query = new SearchQuery { Portability = "true", BatterySupport = "YES", MultiPatientSupport="NO", TouchScreenSupport="true"};
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
