using Autofac;
using Azenix.Log.Concrete.Component;
using Azenix.Log.Concrete.ModelFactory;
using Azenix.Log.Core.Component;
using Azenix.Log.Core.ModelFactory;
using System;

namespace Log.Dependency
{
    public class LogDependencyRegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<LogQueryComponent>()
                  .As<ILogQueryComponent>()
                  .PropertiesAutowired()
                  .InstancePerLifetimeScope();

            builder.RegisterType<LogModelFactory>().As<ILogModelFactory>();
        }
    }
}
