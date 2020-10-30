using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using PurchaseAssistantWebApp.Database;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public class ModelsSpecificationDataRepository : IModelsSpecificationDataRepository
    {
    
        private readonly AppDbContext _context;
        public ModelsSpecificationDataRepository(AppDbContext context)
        {
            _context = context;
        }

        [AssertionMethod]
        private void ValidateStringField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "Model specification required: " + name + " cannot be null or empty.");
            }
        }

        [AssertionMethod]
        private void ValidateModelSpecificationData(ModelsSpecification model)
        {
            ValidateStringField(nameof(model.ProductName), model.ProductName);
            ValidateStringField(nameof(model.ProductKey), model.ProductKey);
            ValidateStringField(nameof(model.Description), model.Description);
            ValidateStringField(nameof(model.Price), model.Price);
            ValidateStringField(nameof(model.MonitorResolution), model.MonitorResolution);
            ValidateStringField(nameof(model.BatterySupport), model.BatterySupport);
            ValidateStringField(nameof(model.MultiPatientSupport), model.MultiPatientSupport);
            ValidateStringField(nameof(model.BpCheck), model.BpCheck);
            ValidateStringField(nameof(model.HeartRateCheck), model.HeartRateCheck);
            ValidateStringField(nameof(model.EcgCheck), model.EcgCheck);
            ValidateStringField(nameof(model.SpO2Check), model.SpO2Check);
            ValidateStringField(nameof(model.TemperatureCheck), model.TemperatureCheck);
            ValidateStringField(nameof(model.CardiacOutputCheck), model.CardiacOutputCheck);
        }

        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return _context.Models.ToList();
        }

        public void AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            ValidateModelSpecificationData(newModelsSpecification);
            if (GetModel(newModelsSpecification.Id) != null)
            {
                throw new ArgumentException($"Model specification with {newModelsSpecification.Id} id already exists.", nameof(newModelsSpecification.Id));
            }
            _context.Models.Add(newModelsSpecification);
            _context.SaveChanges();

        }

        public void UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification)
        {
            ValidateModelSpecificationData(updatedModelsSpecification);

            if (GetModel(updatedModelsSpecification.Id) == null)
            {
                throw new KeyNotFoundException($"Update operation failed. Model specification with { updatedModelsSpecification.Id } id does not exist.");
            }
            Update(GetModel(updatedModelsSpecification.Id), updatedModelsSpecification);
            _context.SaveChanges();
        }

        public void Update(ModelsSpecification oldModel, ModelsSpecification newModel)
        {
            oldModel.ProductName = newModel.ProductName;
            oldModel.ProductKey = newModel.ProductKey;
            oldModel.Description = newModel.Description;
            oldModel.Price = newModel.Price;
            oldModel.Weight = newModel.Weight;
            oldModel.Portable = newModel.Portable;
            oldModel.ScreenSize = newModel.ScreenSize;
            oldModel.TouchScreenSupport = newModel.TouchScreenSupport;
            oldModel.MonitorResolution = newModel.MonitorResolution;
            oldModel.BatterySupport = newModel.BatterySupport;
            oldModel.MultiPatientSupport = newModel.MultiPatientSupport;
            oldModel.BpCheck = newModel.BpCheck;
            oldModel.HeartRateCheck = newModel.HeartRateCheck;
            oldModel.EcgCheck = newModel.EcgCheck;
            oldModel.SpO2Check = newModel.SpO2Check;
            oldModel.TemperatureCheck = newModel.TemperatureCheck;
            oldModel.CardiacOutputCheck = newModel.CardiacOutputCheck;
        }

        public void DeleteModelsSpecification(long id)
        {
            if (GetModel(id) == null)
            {
                throw new KeyNotFoundException($"Delete operation failed. Model specification with { id } id does not exist.");
            }
            _context.Models.Remove(GetModel(id));
            _context.SaveChanges();
        }

        public ModelsSpecification GetModel(long id)
        {
            return _context.Models.Find(id);
        }
    }
}
