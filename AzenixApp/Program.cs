using Autofac;
using Azenix.Data.Dependency;
using Log.Dependency;
using System;

namespace AzenixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new LogDependencyRegisterModule());
            containerBuilder.RegisterModule(new DataDependencyRegisterModule());
            containerBuilder.RegisterType<Query>().InstancePerLifetimeScope().PropertiesAutowired();
            var container = containerBuilder.Build();

            var logs = container.Resolve<Query>().Execute();
            
            int numberOfUniqueIpAdress = container.Resolve<Query>().ExecuteGetNumberOfUniqueIpAddress(logs);
            Console.WriteLine("Number of unique IP Address: " + numberOfUniqueIpAdress);

            Console.WriteLine("Top 3 Active IPs are");
            var topActiveIpAddress = container.Resolve<Query>().ExecuteGetTopActiveIpAddress(logs);            
            foreach (var ip in topActiveIpAddress)
            {
                Console.WriteLine(ip);
            }

            Console.WriteLine("Top 3 visited Urls are");
            var topVisitedUrls = container.Resolve<Query>().ExecuteGetTopVisitedUrls(logs);
            foreach (var url in topVisitedUrls)
            {
                Console.WriteLine(url);
            }
        }
    }
}
