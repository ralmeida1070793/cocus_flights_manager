using Entities;
using Entities.Models;
using Business.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Services
{
    public class AirportService : AbstractService, IBusinessServices<Airport>
    {
        public AirportService(
            IServiceScopeFactory scopeFactory
        ) : base(scopeFactory)
        { }

        public async Task<Airport> CreateAsync(Airport entity, CancellationToken ct)
        {
            var airport = await this._databaseContext.Airports.AddAsync(entity.ToDatabase(), ct);
            this._databaseContext.SaveChanges();
            return airport.Entity.ToModel();
        }

        public async Task<Dictionary<MessageType, string>> DeleteAsync(Airport entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                Dictionary<MessageType, string> result = new Dictionary<MessageType, string>();
                try
                {
                    var airport = this._databaseContext.Airports.Find(entity.Id);
                    this._databaseContext.Airports.Remove(airport);
                    this._databaseContext.SaveChanges();
                }
                catch (Exception e)
                {
                    result.Add(MessageType.ERROR, "An error occured while trying to delete the airport. Exception: " + e.Message);
                }
                finally
                {
                    result.Add(MessageType.SUCCESS, "The airport was successfully deleted.");
                }

                return result;
            }, ct);
            
        }

        public async Task<EntityCollection<Airport>> GetResourceAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                return new EntityCollection<Airport>()
                {
                    Total = this._databaseContext.Airports.Count(),
                    Entities = this._databaseContext.Airports.Select(e => e.ToModel()).ToList()
                };
            }, ct);
        }
        
        public async Task<EntityCollection<Airport>> GetResourceAsync(int itemsPerPage, int page, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                return new EntityCollection<Airport>()
                {
                    Total = this._databaseContext.Airports.Count(),
                    Entities = this._databaseContext.Airports.Skip(page * itemsPerPage).Take(itemsPerPage).Select(e => e.ToModel()).ToList()
                };
            }, ct);
        }
        
        public async Task<Airport> GetById(long id, CancellationToken ct)
        {
            var result = await _databaseContext.Airports.FindAsync(new object[] { id }, ct);
            return result.ToModel();
        }

        public async Task<Airport> UpdateAsync(Airport entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                var airport = this._databaseContext.Airports.Find(entity.Id);
                airport.Latitude = entity.Latitude;
                airport.Longitude = entity.Longitude;
                airport.Name = entity.Name;
                this._databaseContext.Airports.Update(airport);

                this._databaseContext.SaveChanges();
                return airport.ToModel();
            }, ct);
        }
    }
}
