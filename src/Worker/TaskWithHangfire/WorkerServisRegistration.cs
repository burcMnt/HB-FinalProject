using Application.ApplicationCore.Interfaces.MongoDbRepository;
using Application.ApplicationCore.Interfaces.Repository;
using Application.Infrastructure;
using Application.Infrastructure.Repositories;
using Application.Infrastructure.Repositories.MongoDb;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TaskWithHangfire
{
    public static class WorkerServisRegistration
    {
        public static void AddWorkerServices(this IServiceCollection serviceCollection)
        {
            var assmbly = Assembly.GetExecutingAssembly();
            serviceCollection.AddMediatR(assmbly);
           

            serviceCollection.AddTransient<IListedItemRepository, ListedItemRepository>();
            serviceCollection.AddTransient<IListItemsMongoRepository, ListItemsMongoRepository>();
            serviceCollection.AddTransient<IMongoRepository, MongoRepository>();
            serviceCollection.AddScoped<IMongoDbContext, MongoDbContext>();


        }
    }
}
