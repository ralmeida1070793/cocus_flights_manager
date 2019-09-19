using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightService _flightServices;
        private readonly AeroplaneService _aeroplaneServices;

        public FlightsController(
            FlightService flightServices,
            AeroplaneService aeroplaneServices
        )
        {
            _flightServices = flightServices;
            _aeroplaneServices = aeroplaneServices;
        }

        // GET api/flights
        [HttpGet]
        public async Task<IEntityCollection<Flight>> GetFlightsListAsync(CancellationToken ct)
        {
            return await _flightServices.GetResourceAsync(ct);
        }

        // GET api/flights/5
        [HttpGet("{id}")]
        public async Task<Flight> GetFlightAsync(int id, CancellationToken ct)
        {
            return await _flightServices.GetById(id, ct); ;
        }

        // GET api/flights/5/plane/2
        [HttpGet("{id}/plane/{planeId}")]
        public async Task<FlightConsumption> GetFlightConsumptionAsync(int id, int planeId, CancellationToken ct)
        {
            var flight = await _flightServices.GetById(id, ct);
            var plane = await _aeroplaneServices.GetById(planeId, ct);
            var distance = flight.GetFlightDistance();

            return new FlightConsumption()
            {
                Aeroplane = plane,
                Flight = flight,
                DistanceNmi = distance,
                Consumption = plane.GetPlaneConsumption(distance)
            };
        }

        // POST api/flights
        [HttpPost]
        public async Task<Flight> AddFlightAsycn(
            [FromBody] Flight flight,
            CancellationToken ct
        )
        {
            return await _flightServices.CreateAsync(flight, ct);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public async Task<Flight> UpdateFlightAsync(
            int id, 
            [FromBody] Flight flight,
            CancellationToken ct
        )
        {
            return await _flightServices.UpdateAsync(flight, ct);
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public async Task<Dictionary<MessageType, string>> DeleteAsync(int id, CancellationToken ct)
        {
            var flight = await _flightServices.GetById(id, ct);
            return await _flightServices.DeleteAsync(flight, ct);
        }
    }
}