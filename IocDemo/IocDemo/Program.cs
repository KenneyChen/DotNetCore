using Hello.Services;
using Hello.Services.Impl;
using IocDemo.Attribute;
using IocDemo.IocManager;
using System;

namespace IocDemo
{
    class Program
    {
        [Import]
        public static IUserService UserService { get; set; }

        static void Main(string[] args)
        {
            var ioc = new IocContainer();

            var aa = typeof(IUserService);
            var userService = ioc.GetObject< IUserService>();
            userService.GetMenu();

            Console.WriteLine("Hello World!");
        }
    }
}
