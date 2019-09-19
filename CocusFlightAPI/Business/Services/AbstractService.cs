using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public abstract class AbstractService
    {
        protected readonly Database.Context.DbContext _databaseContext;

        protected AbstractService(
            IServiceScopeFactory scopeFactory
        )
        {
            _databaseContext = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<Database.Context.DbContext>(); ;
        }
    }
}
