
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading;
using Configuration.custom;

namespace Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            optionalSimple();



            //reloadOnChangeSimple();

            //AddJson();

            //AddXML();

            //AddMemory();

            //AddCommand(args);
            //AddEnvironmentVariables();

            //AddMany();

            CustomFile();

            Console.ReadKey();
        }

        /// <summary>
        /// 文件不存在会报错
        /// </summary>
        static void optionalSimple()
        {
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("appsettings22222.json", optional: true/*文件不存在会报错*/, reloadOnChange: true /*文件发生变化时候自动更新*/)
             .Build();
        }

        /// <summary>
        /// 文件发生变化时候自动更新
        /// </summary>
        static void reloadOnChangeSimple()
        {
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("appsettings.json", optional: true/*文件不存在会报错*/, reloadOnChange: true /*文件发生变化时候自动更新*/)
             .Build();

            var test = cfg.GetValue<string>("test");
            Console.WriteLine($"GetValue获取test节点:{test}");


            ChangeToken.OnChange(() =>
            {
                var provider = new PhysicalFileProvider(Environment.CurrentDirectory);
                Console.WriteLine("开始监视文件~~~~~~~");
                return provider.Watch("appsettings.json");
            },
            () =>
            {
                Console.WriteLine($"发生变化了,改变后值：{cfg.GetValue<string>("test")}");
            });

            //睡眠10s，如果我修改文件自动获取最新
            Thread.Sleep(1000 * 10);

            var test2 = cfg.GetValue<string>("test");
            Console.WriteLine($"GetValue获取test节点:{test2}");
        }

        static void AddJson()
        {
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("appsettings.json", optional: true/*文件不存在会报错*/, reloadOnChange: true /*文件发生变化时候自动更新*/)
             .Build();

            var test = cfg.GetValue<string>("test");
            Console.WriteLine($"GetValue获取test节点:{test}");

            var MySql = cfg.GetValue<string>("Connections:Mysql");
            Console.WriteLine($"方式①：GetValue获取Connections:MySql节点:{MySql}");

            var connections = cfg.GetSection("Connections");
            var mysql2 = connections.GetValue<string>("Mysql");
            Console.WriteLine($"方式②：GetValue获取Connections:MySql节点:{mysql2}");


            //强类型获取
            var root= cfg.Get<Rootobject>();
            Console.WriteLine($"方式③：GetValue获取Connections:MySql节点:{root.Connections.Mysql}");
        }

        static void AddXML()
        {
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddXmlFile("appsettings.xml", optional: true/*文件不存在会报错*/, reloadOnChange: true /*文件发生变化时候自动更新*/)
             .Build();

            var test = cfg.GetValue<string>("test");
            Console.WriteLine($"GetValue获取test节点:{test}");

            var MySql = cfg.GetValue<string>("Connections:Mysql");
            Console.WriteLine($"方式①：GetValue获取Connections:MySql节点:{MySql}");

            var connections = cfg.GetSection("Connections");
            var mysql2 = connections.GetValue<string>("Mysql");
            Console.WriteLine($"方式②：GetValue获取Connections:MySql节点:{mysql2}");


            //强类型获取
            var root = cfg.Get<Rootobject>();
            Console.WriteLine($"方式③：GetValue获取Connections:MySql节点:{root.Connections.Mysql}");
        }


        static void AddMemory()
        {
            var dic = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("test3","我是测试AddMemory"),
            };
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddInMemoryCollection(dic)
             .Build();

            var test = cfg.GetValue<string>("test3");
            Console.WriteLine($"GetValue获取test节点:{test}");
        }

        static void AddCommand(string[] args)
        {
            
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .AddCommandLine(args)
             .Build();

            var test = cfg["test3"];
            Console.WriteLine($"GetValue获取test3节点:{test}");
        }

        static void AddEnvironmentVariables()
        {

            IConfigurationRoot cfg = new ConfigurationBuilder()
             .AddEnvironmentVariables()
             .Build();

            var test = cfg["test3"];
            Console.WriteLine($"GetValue获取test3节点:{test}");
        }

        static void AddMany()
        {
            var dic = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("test3","我是测试KeyValuePair"),
            };
            IConfigurationRoot cfg = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddInMemoryCollection(dic)
             .AddJsonFile("appsettings.json", optional: true/*文件不存在会报错*/, reloadOnChange: true /*文件发生变化时候自动更新*/)
             .Build();

            var test = cfg.GetValue<string>("test3");
            Console.WriteLine($"GetValue获取test节点:{test}");
        }


        static void CustomFile()
        {
            IConfigurationRoot cfg = new ConfigurationBuilder()
           .SetBasePath(Environment.CurrentDirectory)
           .AddAbcFile("file.abc")
           .Build();


            var test = cfg.GetValue<string>("test3");
            Console.WriteLine($"CustomFile获取test节点:{test}");
        }

    }
    public class Rootobject
    {
        public Connections Connections { get; set; }
        public string test { get; set; }
    }

    public class Connections
    {
        public string Mysql { get; set; }
    }

}
