using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        // GET: api/<VehiclesController>
        [HttpGet]
        public IEnumerable<AutoMobile> Get()
        {
            return _vehicleService.GetVehicles();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id:min(1)}")]
        public AutoMobile Get(int id)
        {
            var result = _vehicleService.GetVehicle(id);

            if (result == null) 
            { 
                // 404 wenn nichts gefunden wurde
                //return NotFound();
            }

            return result;
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public void Post([FromBody] AutoMobile value)
        {
            _vehicleService.AddVehicle(value);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AutoMobile value)
        {
            _vehicleService.UpdateVehicle(id, value);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleService.DeleteVehicle(id);
        }
    }
}
