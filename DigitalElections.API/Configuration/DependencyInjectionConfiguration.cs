using DigitalElections.Domain.Entities;
using DigitalElections.Core.Interfaces.Repositories;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Core.MappingProfiles;
using DigitalElections.Core.Middleware;
using DigitalElections.Core.Services;
using DigitalElections.Domain.Entities;
using DigitalElections.Domain.Services;
using DigitalElections.Infrastructure.Data.Repositories;
using DigitalElections.Infrastructure.Data.Repositories.Base;
using DigitalElections.Infrastructure.Data.Transactions;
using Logar.Core.Interfaces.Transactions;

namespace DigitalElections.API.Configuration;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddInjectionDependency(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UsersProfile), typeof(PersonProfile), typeof(SchoolProfile), typeof(HelpFriendProfile), typeof(ManagerProfile));

        #region Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IHelpFriendService, HelpFriendService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<ITransactionManager, TransactionManager>();
        #endregion

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IHelpFriendRepository, HelpFriendRepository>();
        services.AddScoped<IManagerRepository, ManagerRepository>();
        #endregion

        #region AbstractClasses
        services.AddScoped<IRepository<Users>, UserRepository>();
        services.AddScoped<IRepository<HelpFriend>, HelpFriendRepository>();
        services.AddScoped<IRepository<Person>, PersonRepository>();
        services.AddScoped<IRepository<School>, SchoolRepository>();
        services.AddScoped<IRepository<Manager>, ManagerRepository>();
        #endregion

        #region Middleware
        services.AddScoped<ExceptionHandlerMiddleware>();
        #endregion

        #region Authentication
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtProviderService, JwtProviderService>();
        #endregion

        services.AddHttpContextAccessor();

        return services;
    }
}