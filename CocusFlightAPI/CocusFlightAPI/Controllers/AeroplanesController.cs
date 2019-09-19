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
    [Route("api/aeroplanes")]
    [ApiController]
    public class AeroplanesController : ControllerBase
    {
        private readonly AeroplaneService _aeroplaneServices;

        public AeroplanesController(
            AeroplaneService aeroplaneServices
        )
        {
            _aeroplaneServices = aeroplaneServices;
        }

        [HttpGet]
        public async Task<IEntityCollection<Aeroplane>> GetAeroplanesListAsync(CancellationToken ct)
        {
            return await _aeroplaneServices.GetResourceAsync(ct);
        }

        // GET api/aeroplanes/5
        [HttpGet("{id}")]
        public async Task<Aeroplane> GetAeroplaneAsync(int id, CancellationToken ct)
        {
            return await _aeroplaneServices.GetById(id, ct); ;
        }
        
        // POST api/aeroplanes
        [HttpPost]
        public async Task<Aeroplane> AddAeroplaneAsycn(
            [FromBody] Aeroplane aeroplane,
            CancellationToken ct
        )
        {
            return await _aeroplaneServices.CreateAsync(aeroplane, ct);
        }

        // PUT api/aeroplanes/5
        [HttpPut("{id}")]
        public async Task<Aeroplane> UpdateAeroplaneAsync(
            int id, 
            [FromBody] Aeroplane aeroplane,
            CancellationToken ct
        )
        {
            return await _aeroplaneServices.UpdateAsync(aeroplane, ct);
        }

        // DELETE api/aeroplanes/5
        [HttpDelete("{id}")]
        public async Task<Dictionary<MessageType, string>> DeleteAsync(int id, CancellationToken ct)
        {
            var aeroplane = await _aeroplaneServices.GetById(id, ct);
            return await _aeroplaneServices.DeleteAsync(aeroplane, ct);
        }
    }
}