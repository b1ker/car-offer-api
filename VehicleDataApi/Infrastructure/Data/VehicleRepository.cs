using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using VehicleDataApi.Domain.Entities;

namespace VehicleDataApi.Infrastructure.Data
{
    public class JsonVehicleRepository : IVehicleRepository
    {
        private readonly IEnumerable<Vehicle> _vehicles;
        private readonly ILogger<JsonVehicleRepository> _logger;

        public JsonVehicleRepository(ILogger<JsonVehicleRepository> logger)
        {
            _logger = logger;
            try
            {
                string jsonData = System.IO.File.ReadAllText("honda_wmi.json");
                _vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonData);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicles;
        }
    }

    public interface IVehicleRepository
    {
        public IEnumerable<Vehicle> GetAll();
    }
}
