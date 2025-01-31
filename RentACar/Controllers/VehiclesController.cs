using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACarApi.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        return Ok(vehicles.Select(v => v.ToVehicleDto()));
    }

    // GET api/<VehiclesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleResultDto>> GetAsync(Guid id)
    {
        var vehicle = await _vehicleService.GetVehicleAsync(id);
        if (vehicle == null)
        {
            // 404 wenn nichts gefunden wurde
            return NotFound();
        }

        return Ok(vehicle.ToVehicleDto());
    }

    // POST api/<VehiclesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] VehicleDto value)
    {
        // Validierung, ob Parameter gueltig sind
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var guid = await _vehicleService.AddVehicleAsync(value.ToEntity());
        return Ok(guid);
    }

    // PUT api/<VehiclesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleDto value)
    {
        // Validierung, ob Parameter gueltig sind
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = await _vehicleService.UpdateVehicleAsync(id, value.ToEntity());
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
