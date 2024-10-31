using DigitalElections.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalElections.API.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Habilita o comportamento legado de timestamp
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configura o DbContext com a string de conexão
            services.AddDbContext<DigitalElectionsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DigitalElections")));
        }
    }
}
