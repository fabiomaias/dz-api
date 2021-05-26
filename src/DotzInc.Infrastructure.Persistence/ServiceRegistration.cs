using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotzInc.Infrastructure.Persistence.Contexts;
using DotzInc.Infrastructure.Persistence.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using DotzInc.Application.Interfaces;
using DotzInc.Application.Interfaces.Repositories;

namespace DotzInc.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DotzDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                                 b => b.MigrationsAssembly(typeof(DotzDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICreditCardRepository, CreditCardRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            #endregion
            WaitForDBInit(configuration.GetConnectionString("DefaultConnection"));
        }

        public static void WaitForDBInit(string connectionString)
        {
            var connection = new MySqlConnection(connectionString);
            int retries = 1;
            while (retries < 7)
            {
                try
                {
                    Console.WriteLine("Conectando ao Banco de dados. Tentativa: {0} de 7", retries);
                    connection.Open();
                    connection.Close();
                    break;
                }
                catch (MySqlException)
                {
                    Thread.Sleep((int)Math.Pow(2, retries) * 1000);
                    retries++;
                }
            }
        }
    }
}
