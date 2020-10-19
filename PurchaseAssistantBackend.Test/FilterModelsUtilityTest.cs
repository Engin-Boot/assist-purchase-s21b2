using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Utilities;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class FilterModelsUtilityTest
    {
        List<ModelsSpecification> models;
        public FilterModelsUtilityTest()
        {
            models = new List<ModelsSpecification> {
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

        [Fact]
        public void WhenApplyFilterByIdWithNullOrEmptyIdThenReturnAllModels()
        {
            var filteredModelsById = FilterModelsUtility.FilterById("", models);
            Assert.Equal(2, filteredModelsById.Count());

            filteredModelsById = FilterModelsUtility.FilterById(null, models);
            Assert.Equal(2, filteredModelsById.Count());
        }

        [Fact]
        public void WhenApplyFilterByIdWithNonIntegerIdThenThrowException()
        {
            try
            {
                var filteredModelsById = FilterModelsUtility.FilterById("abc", models);
            }
            catch(ArgumentException exception)
            {
                Assert.Equal("id", exception.ParamName);
                Assert.Equal("Query Argument 'id' is invalid. Id must be a long number. (Parameter 'id')", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByIdWithValidIdThenReturnModelsWithMatchingId()
        {
            var filteredModelsById = FilterModelsUtility.FilterById("1", models);
            Assert.Single(filteredModelsById);

            var model = filteredModelsById.First();
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

        [Fact]
        public void WhenApplyFilterByProductNameWithNullOrEmptyProductNameValueThenReturnAllModels()
        {
            var filteredModelsByProductName = FilterModelsUtility.FilterByProductName("", models);
            Assert.Equal(2, filteredModelsByProductName.Count());

            filteredModelsByProductName = FilterModelsUtility.FilterByProductName(null, models);
            Assert.Equal(2, filteredModelsByProductName.Count());
        }

        [Fact]
        public void WhenApplyFilterByProductNameWithValidProductNameThenReturnModelsWithMatchingProductName()
        {
            var filteredModelsByProductName = FilterModelsUtility.FilterByProductName("IntelliVue", models);
            Assert.Single(filteredModelsByProductName);

            var model = filteredModelsByProductName.First();
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

        [Fact]
        public void WhenApplyFilterByProductKeyWithNullOrEmptyProductKeyValueThenReturnAllModels()
        {
            var filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey("", models);
            Assert.Equal(2, filteredModelsByProductKey.Count());

            filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey(null, models);
            Assert.Equal(2, filteredModelsByProductKey.Count());
        }

        [Fact]
        public void WhenApplyFilterByProductKeyWithValidProductKeyThenReturnModelsWithMatchingProductKey()
        {
            var filteredModelsByProductKey = FilterModelsUtility.FilterByProductKey("X3", models);
            Assert.Single(filteredModelsByProductKey);

            var model = filteredModelsByProductKey.First();
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

        [Fact]
        public void WhenApplyFilterByPortabilityWithNullOrEmptyPortabilityThenReturnAllModels()
        {
            var filteredModelsByPortability = FilterModelsUtility.FilterByPortability("", models);
            Assert.Equal(2, filteredModelsByPortability.Count());

            filteredModelsByPortability = FilterModelsUtility.FilterByPortability(null, models);
            Assert.Equal(2, filteredModelsByPortability.Count());
        }

        [Fact]
        public void WhenApplyFilterByPortabilityWithNonBooleanValueThenThrowException()
        {
            try
            {
                var filteredModelsByPortability = FilterModelsUtility.FilterByPortability("required", models);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("portability", exception.ParamName);
                Assert.Equal("Query Argument 'portability' is invalid. It must be a boolean value (either true or false). (Parameter 'portability')", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByPortabilityWithValidBooleanValueThenReturnModelsWithMatchingPortability()
        {
            var filteredModelsByPortability = FilterModelsUtility.FilterByPortability("true", models);
            Assert.Equal(2, filteredModelsByPortability.Count());

            var modelList = filteredModelsByPortability.ToList();

            Assert.Equal("IntelliVue", modelList[0].ProductName);
            Assert.Equal("X3", modelList[0].ProductKey);
            Assert.Equal("The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.", 
                modelList[0].Description);
            Assert.Equal("14500", modelList[0].Price);
            Assert.Equal(65, modelList[0].Weight);
            Assert.True(modelList[0].Portable);
            Assert.Equal(6.1, modelList[0].ScreenSize);
            Assert.True(modelList[0].TouchScreenSupport);
            Assert.Equal("10*11", modelList[0].MonitorResolution);
            Assert.Equal("NO", modelList[0].BatterySupport);
            Assert.Equal("NO", modelList[0].MultiPatientSupport);

            Assert.Equal("Intelli", modelList[1].ProductName);
            Assert.Equal("MX40", modelList[1].ProductKey);
            Assert.Equal("The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.", 
                modelList[1].Description);
            Assert.Equal("37000", modelList[1].Price);
            Assert.Equal(65, modelList[1].Weight);
            Assert.True(modelList[1].Portable);
            Assert.Equal(2.8, modelList[1].ScreenSize);
            Assert.True(modelList[1].TouchScreenSupport);
            Assert.Equal("10*11", modelList[1].MonitorResolution);
            Assert.Equal("YES", modelList[1].BatterySupport);
            Assert.Equal("NO", modelList[1].MultiPatientSupport);
        }
        [Fact]
        public void WhenApplyFilterByBatterySupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport("", models);
            Assert.Equal(2, filteredModelsByBatterySupport.Count());

            filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport(null, models);
            Assert.Equal(2, filteredModelsByBatterySupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByBatterySupportWithValidValueThenReturnModelsWithMatchingBatterySupport()
        {
            var filteredModelsByBatterySupport = FilterModelsUtility.FilterByBatterySupport("YES", models);
            Assert.Single(filteredModelsByBatterySupport);

            var model = filteredModelsByBatterySupport.First();
            
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
        public void WhenApplyFilterByMultiPatientSupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport("", models);
            Assert.Equal(2, filteredModelsByMultiPatientSupport.Count());

            filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport(null, models);
            Assert.Equal(2, filteredModelsByMultiPatientSupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByMultiPatientSupportWithValidValueThenReturnModelsWithMatchingMultiPatientSupport()
        {
            var filteredModelsByMultiPatientSupport = FilterModelsUtility.FilterByMultiPatientSupport("YES", models);
            Assert.Empty(filteredModelsByMultiPatientSupport);
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithNullOrEmptyValueThenReturnAllModels()
        {
            var filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport("", models);
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count());

            filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport(null, models);
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count());
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithNonBooleanValueThenThrowException()
        {
            try
            {
                var filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport("required", models);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("touchScreenSupport", exception.ParamName);
                Assert.Equal("Query Argument 'touchScreenSupport' is invalid. It must be a valid boolean value (either true or false). (Parameter 'touchScreenSupport')", exception.Message);
            }
        }

        [Fact]
        public void WhenApplyFilterByTouchScreenSupportWithValidBooleanValueThenReturnModelsWithMatchingTouchScreenSupportValue()
        {
            var filteredModelsByTouchScreenSupport = FilterModelsUtility.FilterByTouchScreenSupport("true", models);
            Assert.Equal(2, filteredModelsByTouchScreenSupport.Count());

            var modelList = filteredModelsByTouchScreenSupport.ToList();

            Assert.Equal("IntelliVue", modelList[0].ProductName);
            Assert.Equal("X3", modelList[0].ProductKey);
            Assert.Equal("The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
                modelList[0].Description);
            Assert.Equal("14500", modelList[0].Price);
            Assert.Equal(65, modelList[0].Weight);
            Assert.True(modelList[0].Portable);
            Assert.Equal(6.1, modelList[0].ScreenSize);
            Assert.True(modelList[0].TouchScreenSupport);
            Assert.Equal("10*11", modelList[0].MonitorResolution);
            Assert.Equal("NO", modelList[0].BatterySupport);
            Assert.Equal("NO", modelList[0].MultiPatientSupport);

            Assert.Equal("Intelli", modelList[1].ProductName);
            Assert.Equal("MX40", modelList[1].ProductKey);
            Assert.Equal("The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                modelList[1].Description);
            Assert.Equal("37000", modelList[1].Price);
            Assert.Equal(65, modelList[1].Weight);
            Assert.True(modelList[1].Portable);
            Assert.Equal(2.8, modelList[1].ScreenSize);
            Assert.True(modelList[1].TouchScreenSupport);
            Assert.Equal("10*11", modelList[1].MonitorResolution);
            Assert.Equal("YES", modelList[1].BatterySupport);
            Assert.Equal("NO", modelList[1].MultiPatientSupport);
        }

        [Fact]
        public void WhenApplyAllFiltersThenReturnFilteredModelsResult()
        {
            SearchQuery query = new SearchQuery { Portability = "true", BatterySupport = "YES", MultiPatientSupport="NO", TouchScreenSupport="true"};
            var filteredModels = FilterModelsUtility.ApplyAllFilters(models, query);
            var filteredModelsList = filteredModels.ToList();

            Assert.Single(filteredModelsList);

            Assert.Equal("Intelli", filteredModelsList[0].ProductName);
            Assert.Equal("MX40", filteredModelsList[0].ProductKey);
            Assert.Equal("The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                filteredModelsList[0].Description);
            Assert.Equal("37000", filteredModelsList[0].Price);
            Assert.Equal(65, filteredModelsList[0].Weight);
            Assert.True(filteredModelsList[0].Portable);
            Assert.Equal(2.8, filteredModelsList[0].ScreenSize);
            Assert.True(filteredModelsList[0].TouchScreenSupport);
            Assert.Equal("10*11", filteredModelsList[0].MonitorResolution);
            Assert.Equal("YES", filteredModelsList[0].BatterySupport);
            Assert.Equal("NO", filteredModelsList[0].MultiPatientSupport);

            query = new SearchQuery { ProductName = "IntelliVue", ProductKey = "X3" };
            filteredModels = FilterModelsUtility.ApplyAllFilters(models, query);
            Assert.Single(filteredModels);

            query = new SearchQuery { Id = "1" };
            filteredModels = FilterModelsUtility.ApplyAllFilters(models, query);
            Assert.Single(filteredModels);
        }
    }
}
