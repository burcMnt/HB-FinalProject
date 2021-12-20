using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.ApplicationCore
{
    public static class ApplicationServisRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            var assmbly = Assembly.GetExecutingAssembly();
            serviceCollection.AddMediatR(assmbly);
        }
    }
}
