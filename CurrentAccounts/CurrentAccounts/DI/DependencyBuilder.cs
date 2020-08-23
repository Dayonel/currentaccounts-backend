using CurrentAccounts.Core.Interfaces.Repository;
using CurrentAccounts.Core.Interfaces.Repository.Base;
using CurrentAccounts.Core.Interfaces.Services;
using CurrentAccounts.Core.Services;
using CurrentAccounts.Core.Settings;
using CurrentAccounts.Data;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Data.Repository.Base;
using CurrentAccounts.Infrastructure.HostedServices.Services;
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
            services.AddDbContext<CurrentAccountsDbContext>(options => options.UseSqlite(configuration.BindSettings<DbSettings>(nameof(DbSettings)).ConnectionString));
            #endregion

            #region Services
            services.AddTransient<IBankAccountService, BankAccountService>();
            #endregion

            #region Repository
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionScopedRepository, TransactionScopedRepository>();
            #endregion

            #region Hosted services
            services.AddHostedService<DbDataSeeder>();
            #endregion
        }
    }
}