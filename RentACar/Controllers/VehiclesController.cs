using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleServiceAsync _vehicleService;
    private readonly ILogger<VehiclesController> _logger;

    public VehiclesController(IVehicleServiceAsync vehicleService, ILogger<VehiclesController> logger)
    {
        _vehicleService = vehicleService;
        _logger = logger;
    }

    // GET: api/<VehiclesController>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var vehicles = await _vehicleService.GetVehiclesAsync();
        return Ok(vehicles);
    }

    // GET api/<VehiclesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AutoMobile>> GetAsync(Guid id)
    {
        var vehicle = await _vehicleService.GetVehicleAsync(id);
        if (vehicle == null)
        {
            // 404 wenn nichts gefunden wurde
            return NotFound();
        }

        return Ok(vehicle);
    }

    // POST api/<VehiclesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AutoMobile value)
    {
        await _vehicleService.AddVehicleAsync(value);
        return Ok();
    }

    // PUT api/<VehiclesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] AutoMobile value)
    {
        var success = await _vehicleService.UpdateVehicleAsync(id, value);
        if (success)
        {
            return Ok();
        }
        return NotFound();
    }

    // DELETE api/<VehiclesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var success = await _vehicleService.DeleteVehicleAsync(id);
        if (success)
        {
            return Ok();
        }
        return NotFound();
    }
}
