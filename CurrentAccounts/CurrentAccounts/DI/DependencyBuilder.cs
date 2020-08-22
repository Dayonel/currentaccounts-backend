﻿using CurrentAccounts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentAccounts.DI
{
    public static class DependencyBuilder
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB
            services.AddDbContext<CurrentAccountsDbContext>(options => options.UseInMemoryDatabase(nameof(CurrentAccounts)));
            #endregion
        }
    }
}