using System;
using System.Threading.Tasks;

using Autofac;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NLog.Extensions.Logging;

using RestKami.Core;
using RestKami.Core.Interfaces;

namespace RestKami
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddNLog("nlog.config");
            });

            var container = CoreModule.Build(services);

            using (var scope = container.BeginLifetimeScope())
            {
                var seedDataGenerator = scope.Resolve<IStringSeedDataGenerator>();

                var testCaseBuilder = new TestCaseBuilder();
                var testCase = testCaseBuilder
                    .VerifiableUrl("http://localhost:8000/weatherforecast/[param1]/[param2]")
                    .WithSeed(seedDataGenerator.GenerateDefaultString(), forParam: "param1")
                    .WithSeed(seedDataGenerator.GenerateDefaultString(), forParam: "param2")
                    .ShouldReturnStatusCode(200)
                    .Build();

                var routeParameterVerifier = scope.Resolve<IRouteParameterVerifier>();
                await routeParameterVerifier.Verify(testCase);
            }

            Console.WriteLine("Completed");
        }
    }
}
