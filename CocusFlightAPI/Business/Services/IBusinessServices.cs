using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services
{
    /// <summary>
    /// Interface for abstraction of the available business services
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface IBusinessServices<E>
    {
        Task<EntityCollection<E>> GetResourceAsync(CancellationToken ct);

        Task<EntityCollection<E>> GetResourceAsync(int itemsPerPage, int page, CancellationToken ct);

        Task<E> GetById(long id, CancellationToken ct);

        Task<E> CreateAsync(E entity, CancellationToken ct);
        Task<E> UpdateAsync(E entity, CancellationToken ct);
        Task<Dictionary<MessageType, string>> DeleteAsync(E entity, CancellationToken ct);
    }
}
