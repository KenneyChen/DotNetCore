using IocDemo.Attribute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IocDemo.IocManager
{
    public class IocContainer
    {
        //手写ioc容器
        /*
         1、初始化：加载所有dll
         2、条件：给类打上特性才处理
         3、反射得到对象实例
         4、解决相互引用问题
         5、封装成一个独立类库
         */
        public Dictionary<string, object> CacheObjects = new Dictionary<string, object>();

        public IocContainer()
        {
            Dictionary<string, Type> keyValuePairs = new Dictionary<string, Type>();
            //01加载dll
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var item in assembly.GetTypes())
            {
                if (item.IsClass)
                {
                    //02 找到所有类
                    keyValuePairs.Add(item.Name, item);
                }
            }
            //03 反射得到类对象
            foreach (var item in keyValuePairs)
            {
                var interfaces = item.Value.GetInterfaces();
                if (interfaces.Length > 0)
                {
                    //反射得到类实例
                    var obj = Activator.CreateInstance(item.Value);
                    CacheObjects.Add(interfaces[0].Name, obj);
                }
                else
                {
                    //TODO:类没有实现接口，直接实例化
                }
            }

            //04 找到类对应属性，并将他们实例化
            foreach (var item in keyValuePairs)
            {
                foreach (var prop in item.Value.GetProperties())
                {
                    var propKey = prop.PropertyType.Name;
                    if (CacheObjects.ContainsKey(propKey))
                    {
                        prop.SetValue(item, CacheObjects[propKey]);
                    }
                }
            }
        }


        public T GetObject<T>() where T : class
        {
            if (CacheObjects.ContainsKey(typeof(T).Name))
            {
                return (T)CacheObjects[typeof(T).Name];
            }

            return default(T);
        }
    }
}
