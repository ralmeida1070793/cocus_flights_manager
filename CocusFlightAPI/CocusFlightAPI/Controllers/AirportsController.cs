using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Business.Services;
using Entities;
using Entities.Models;
using Entities.ViewModels;
using Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CocusFlightAPI.Controllers
{
    [Route("api/airports")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly AirportService _airportServices;

        public AirportsController(
            AirportService airportServices
        )
        {
            _airportServices = airportServices;
        }

        [HttpGet]
        public async Task<EntityCollection<Airport>> GetAirportsListAsync(CancellationToken ct)
        {
            return await _airportServices.GetResourceAsync(ct);
        }

        // GET api/airports/5
        [HttpGet("{id}")]
        public async Task<Airport> GetAirportAsync(int id, CancellationToken ct)
        {
            return await _airportServices.GetById(id, ct); ;
        }
        
        // POST api/airports
        [HttpPost]
        public async Task<Airport> AddAirportAsycn(
            [FromBody] Airport airport,
            CancellationToken ct
        )
        {
            return await _airportServices.CreateAsync(airport, ct);
        }

        // PUT api/airports/5
        [HttpPut("{id}")]
        public async Task<Airport> UpdateAirportAsync(
            int id, 
            [FromBody] Airport airport,
            CancellationToken ct
        )
        {
            return await _airportServices.UpdateAsync(airport, ct);
        }

        // DELETE api/airports/5
        [HttpDelete("{id}")]
        public async Task<Dictionary<MessageType, string>> DeleteAsync(int id, CancellationToken ct)
        {
            var airport = await _airportServices.GetById(id, ct);
            return await _airportServices.DeleteAsync(airport, ct);
        }
    }
}