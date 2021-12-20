using Application.ApplicationCore.Interfaces.MongoDbRepository;
using Application.ApplicationCore.Interfaces.Repository;
using Application.Infrastructure.Repositories;
using Application.Infrastructure.Repositories.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Infrastructure
{
    public static class InfraServisRegistration
    {
        public static void AddInfraServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped(typeof(IAsyncGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IItemRepository, ItemRepository>();
            serviceCollection.AddScoped<IListOfUserRepository, ListOfUserRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>(); 
            serviceCollection.AddScoped<IListOfUserItemRepository, ListOfUserItemRepository>(); 



            serviceCollection.AddScoped<IMongoDbContext,MongoDbContext>();
            serviceCollection.AddScoped<IMongoRepository,MongoRepository>();
            serviceCollection.AddScoped<IListItemsMongoRepository,ListItemsMongoRepository>();
            serviceCollection.AddScoped<IListedItemRepository,ListedItemRepository>();
        }
    }
}
