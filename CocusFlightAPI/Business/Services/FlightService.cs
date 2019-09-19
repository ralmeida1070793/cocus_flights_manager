using Entities;
using Entities.Models;
using Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FlightService : AbstractService, IBusinessServices<Flight>
    {
        private AirportService _airportService;

        public FlightService(
            IServiceScopeFactory serviceScope,
            AirportService airportService
        ) : base(serviceScope)
        {
            _airportService = airportService;
        }

        public async Task<Flight> CreateAsync(Flight entity, CancellationToken ct)
        {
            var flight = await this._databaseContext.Flights.AddAsync(
                new Database.Context.Flight()
                {
                    DestinationId = entity.Destination.Id.GetValueOrDefault(),
                    OriginId = entity.Departure.Id.GetValueOrDefault()
                }, ct
            );
            this._databaseContext.SaveChanges();

            return new Flight()
            {
                Id = flight.Entity.Id,
                Destination = await _airportService.GetById(flight.Entity.DestinationId, ct),
                Departure = await _airportService.GetById(flight.Entity.OriginId, ct)
            };
        }

        public async Task<Dictionary<MessageType,string>> DeleteAsync(Flight entity, CancellationToken ct)
        {
            Dictionary<MessageType, string> result = new Dictionary<MessageType, string>();
            try
            {
                var flight = await this._databaseContext.Flights.FindAsync(new object[] { entity.Id }, ct);
                this._databaseContext.Flights.Remove(flight);
                this._databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                result.Add(MessageType.ERROR, "An error occured while trying to delete the flight. Exception: " + e.Message);
            }
            finally
            {
                result.Add(MessageType.SUCCESS, "The flight was successfully deleted.");
            }

            return result;
        }

        public async Task<Flight> GetById(long id, CancellationToken ct)
        {
            var result = await this._databaseContext.Flights.FindAsync(new object[] { id }, ct);
            return new Flight()
            {
                Id = result.Id,
                Destination = await _airportService.GetById(result.DestinationId, ct),
                Departure = await _airportService.GetById(result.OriginId, ct)
            };
        }

        public async Task<EntityCollection<Flight>> GetResourceAsync(CancellationToken ct)
        {
            var result = new EntityCollection<Flight>()
            {
                Total = this._databaseContext.Flights.Count(),
                Entities = new List<Flight>()
            };

            var list = this._databaseContext.Flights.ToList();
            foreach(var flight in list)
            {
                result.Entities.Add(new Flight() {
                    Id = flight.Id,
                    Departure = await _airportService.GetById(flight.OriginId, ct),
                    Destination = await _airportService.GetById(flight.DestinationId, ct)
                });
            }

            return result;
        }
        
        public async Task<EntityCollection<Flight>> GetResourceAsync(int itemsPerPage, int page, CancellationToken ct)
        {
            var result = new EntityCollection<Flight>();

                var list = this._databaseContext.Flights.Skip(page * itemsPerPage).Take(itemsPerPage).ToList();
            foreach (var flight in list)
            {
                result.Add(new Flight()
                {
                    Id = flight.Id,
                    Destination = await _airportService.GetById(flight.DestinationId, ct),
                    Departure = await _airportService.GetById(flight.OriginId, ct)
                });
            }

            return result;
        }

        public async Task<Flight> UpdateAsync(Flight entity, CancellationToken ct)
        {
            
            var flight = await this._databaseContext.Flights.FindAsync(new object[] { entity.Id }, ct);
            flight.DestinationId = entity.Destination.Id.GetValueOrDefault();
            flight.OriginId = entity.Departure.Id.GetValueOrDefault();

            this._databaseContext.Flights.Update(flight);
            this._databaseContext.SaveChanges();

            return new Flight()
            {
                Id = flight.Id,
                Destination = await _airportService.GetById(flight.DestinationId, ct),
                Departure = await _airportService.GetById(flight.OriginId, ct)
            };
        }
    }
}
