using Autofac;
using Azenix.Data.Concrete;
using Azenix.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azenix.Data.Dependency
{
    public class DataDependencyRegisterModule : Module
    {        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataLoaderComponent>()
                  .As<IDataLoaderComponent>()
                  .PropertiesAutowired()
                  .InstancePerLifetimeScope();
        }
    }
}
