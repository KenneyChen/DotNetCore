using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Aufofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method.All of this starts
            //with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
             //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
             //     .As<IValuesService>()
             //   .InstancePerLifetimeScope();
        }
    }
}
