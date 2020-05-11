using System;
using System.Collections.Generic;

namespace PipelineDemo
{
    class Program
    {


        static void Main(string[] args)
        {
            var app = new ApplicationBuilder();
            var http = new HttpContext();

            app.Use(next =>
            {
                return new RequestDelegate((d) =>
                {
                    Console.WriteLine("我是item01方法");
                    return next(http);
                });
            });

            app.Use(next =>
            {
                return new RequestDelegate((d) =>
                {
                    Console.WriteLine("我是item02方法");
                    return next(http);
                });
            });

            app.Use(next =>
            {
                return new RequestDelegate((d) =>
                {
                    Console.WriteLine("我是item03方法");
                    return next(http);
                });
            });

            app.UserItem04(http);

            app.Build().Invoke(http);

        }

    }
}
