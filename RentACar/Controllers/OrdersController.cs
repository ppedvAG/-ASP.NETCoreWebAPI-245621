﻿using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderServiceAsync _service;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(IOrderServiceAsync vehicleService, ILogger<OrdersController> logger)
    {
        _service = vehicleService;
        _logger = logger;
    }

    // GET: api/<OrdersController>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var vehicles = await _service.GetOrdersAsync();
        return Ok(vehicles);
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetAsync(Guid id)
    {
        var vehicle = await _service.GetOrderAsync(id);
        if (vehicle == null)
        {
            // 404 wenn nichts gefunden wurde
            return NotFound();
        }

        return Ok(vehicle);
    }

    // POST api/<OrdersController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Order value)
    {
        await _service.AddOrderAsync(value);
        return Ok();
    }

    // PUT api/<OrdersController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] Order value)
    {
        var success = await _service.UpdateOrderAsync(id, value);
        if (success)
        {
            return Ok();
        }
        return NotFound();
    }

    // DELETE api/<OrdersController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var success = await _service.DeleteOrderAsync(id);
        if (success)
        {
            return Ok();
        }
        return NotFound();
    }
}
