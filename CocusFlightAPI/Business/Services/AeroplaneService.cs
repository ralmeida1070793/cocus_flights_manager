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
    public class AeroplaneService : AbstractService, IBusinessServices<Aeroplane>
    {
        public AeroplaneService(
            IServiceScopeFactory scopeFactory
        ) : base(scopeFactory)
        { }

        public async Task<Aeroplane> CreateAsync(Aeroplane entity, CancellationToken ct)
        {
            var aeroplane = await this._databaseContext.Aeroplanes.AddAsync(entity.ToDatabase(), ct);
            this._databaseContext.SaveChanges();
            return aeroplane.Entity.ToModel();
        }

        public async Task<Dictionary<MessageType, string>> DeleteAsync(Aeroplane entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                Dictionary<MessageType, string> result = new Dictionary<MessageType, string>();
                try
                {
                    var aeroplane = this._databaseContext.Aeroplanes.Find(entity.Id);
                    this._databaseContext.Aeroplanes.Remove(aeroplane);
                    this._databaseContext.SaveChanges();
                }
                catch (Exception e)
                {
                    result.Add(MessageType.ERROR, "An error occured while trying to delete the aeroplane. Exception: " + e.Message);
                }
                finally
                {
                    result.Add(MessageType.SUCCESS, "The aeroplane was successfully deleted.");
                }

                return result;
            }, ct);
            
        }

        public async Task<EntityCollection<Aeroplane>> GetResourceAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                return new EntityCollection<Aeroplane>()
                {
                    Total = this._databaseContext.Aeroplanes.Count(),
                    Entities = this._databaseContext.Aeroplanes.Select(e => e.ToModel()).ToList()
                };
            }, ct);
        }
        
        public async Task<EntityCollection<Aeroplane>> GetResourceAsync(int itemsPerPage, int page, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                return new EntityCollection<Aeroplane>()
                {
                    Total = this._databaseContext.Aeroplanes.Count(),
                    Entities = this._databaseContext.Aeroplanes.Skip(page * itemsPerPage).Take(itemsPerPage).Select(e => e.ToModel()).ToList()
                };
            }, ct);
        }

        public async Task<Aeroplane> UpdateAsync(Aeroplane entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                var aeroplane = this._databaseContext.Aeroplanes.Find(entity.Id);
                aeroplane.Capacity = entity.Capacity;
                aeroplane.FuelConsumptionPerSeat = entity.FuelConsumptionPerSeat;
                aeroplane.MilesToCruisingAltitude = entity.MilesToCruisingAltitude;
                aeroplane.Name = entity.Name;
                aeroplane.TakeoffEffortPerOccupiedSeat = entity.TakeoffEffortPerOccupiedSeat;

                this._databaseContext.Update(aeroplane);
                this._databaseContext.SaveChanges();
                return aeroplane.ToModel();
            }, ct);
        }

        public async Task<Aeroplane> GetById(long id, CancellationToken ct)
        {
            var result = await this._databaseContext.Aeroplanes.FindAsync(new object[] { id }, ct);
            return result.ToModel();
        }
    }
}
