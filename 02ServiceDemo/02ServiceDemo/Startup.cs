using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _02ServiceDemo.Aufofac;
using _02ServiceDemo.Services;
using _02ServiceDemo.Services.Impl;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutofacLib.Services;
using AutofacLib.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _02ServiceDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public ILifetimeScope AutofacContainer { get; private set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddControllers();

            ////������
            //services.AddScoped<IMyScopeOrderService, MyScopeOrderServiceImpl>();

            ////����
            //services.AddSingleton<IMySingletonOrderService, MySingletonServiceImpl>();

            ////˲ʱ
            //services.AddTransient<IMyTansientOrderService, MyTransientServiceImpl>();

            ////�Ƴ�
            //services.Remove(new ServiceDescriptor(typeof(IMySingletonOrderService), typeof(MySingletonServiceImpl), ServiceLifetime.Singleton));

            ////�����
            //services.Add(new ServiceDescriptor(typeof(IMySingletonOrderService), typeof(MySingletonServiceImpl2), ServiceLifetime.Singleton));



            ////��ʼ������
            //var builder = new ContainerBuilder();

            //var dllPath = Directory.GetCurrentDirectory();
            //var files = Directory.GetFiles(dllPath, "02ServiceDemo.dll", SearchOption.AllDirectories);
            //foreach (var file in files)
            //{
            //    var assembly = Assembly.LoadFile(file);
            //    foreach (var item in assembly.GetTypes())
            //    {
            //        if (item.IsClass && item.Name.EndsWith("Impl"))
            //        {
            //            var interfaceType = item.GetInterfaces()[0];
            //            services.Add(new ServiceDescriptor(interfaceType, item, ServiceLifetime.Scoped));
            //        }
            //    }
            //}

            ////�鿴
            //var provider = services.BuildServiceProvider();
            //var s1 = provider.GetService<IMySingletonOrderService>();
            //s1.Test();

            //var log=provider.GetService<ILogger<Startup>>();
            //log.BeginScope

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.

            //builder.RegisterModule(new AutofacModule());

            //ע������
            //builder.RegisterType<AutofacDemoServiceImpl>().As<IAutofacDemotService>();

            //����ע��
            //builder.RegisterType<AutofacDemoServiceImpl>().As<IAutofacDemotService>().PropertiesAutowired();
            ////����ע��
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            ////aop
            builder.RegisterType<MyInterceptor>();
            builder.RegisterType<AutofacDemoServiceImpl>()
                .As<IAutofacDemotService>()
                .PropertiesAutowired()
                .InterceptedBy(typeof(MyInterceptor))
                .EnableInterfaceInterceptors();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //var s1 = app.ApplicationServices.GetService<IMyTansientOrderService>();
            //var s2 = app.ApplicationServices.GetService<IMyTansientOrderService>();

            //Console.WriteLine($"s1:{s1.GetHashCode()}");
            //Console.WriteLine($"s2:{s2.GetHashCode()}");

            //var s1 = app.ApplicationServices.GetService<IMyTansientOrderService>();
            //var s2 = app.ApplicationServices.GetService<IMyTansientOrderService>();

            // If, for some reason, you need a reference to the built container, you
            // can use the convenience extension method GetAutofacRoot.
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
