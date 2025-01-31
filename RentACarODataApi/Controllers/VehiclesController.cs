using BusinessModel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace RentACarODataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ODataController
    {
        private readonly VehicleDbContext context;

        /// <summary>
        /// OData eignet sich gut fuer <see cref="https://de.wikipedia.org/wiki/Command-Query-Responsibility-Segregation"/>CQRS Entwurfsmuster.
        /// D. h. Lese- und Schreibvorgaenge sind voneinander getrennt.
        /// </summary>
        /// <param name="context"></param>
        public VehiclesController(VehicleDbContext context)
        {
            this.context = context;
        }

        [HttpGet, EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.Vehicles.ToListAsync());
        }
    }
}
