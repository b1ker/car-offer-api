using System.Collections.Generic;
using VehicleDataApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using VehicleDataApi.Domain.Entities;

namespace VehicleDataApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDataController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleDataController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleRepository.GetAll();
        }
    }
}
