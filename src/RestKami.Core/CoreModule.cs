using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using RestKami.Core.Interfaces;

namespace RestKami.Core
{
    public static class CoreModule
    {
        public static IContainer Build(ServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<StringSeedDataGenerator>()
                .As<IStringSeedDataGenerator>();

            builder.RegisterType<PermutationHelper>()
                .As<IPermutationHelper>();

            builder.RegisterType<RouteParameterVerifier>()
                .As<IRouteParameterVerifier>();

            builder.RegisterType<RestApiService>()
                .As<IRestApiService>();

            var container = builder.Build();

            return container;
        }
    }
}
