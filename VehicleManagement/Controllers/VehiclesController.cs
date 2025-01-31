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
        public IActionResult Get()
        {
            return Ok(_vehicleService.GetVehicles());
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public ActionResult<AutoMobile> Get(Guid id)
        {
            var vehicle = _vehicleService.GetVehicle(id);
            if (vehicle == null) 
            {
                // 404 wenn nichts gefunden wurde
                return NotFound();
            }

            var result = new ActionResult<AutoMobile>(vehicle);
            return Ok(vehicle);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public void Post([FromBody] AutoMobile value)
        {
            _vehicleService.AddVehicle(value);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AutoMobile value)
        {
            var success = _vehicleService.UpdateVehicle(id, value);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var success = _vehicleService.DeleteVehicle(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
