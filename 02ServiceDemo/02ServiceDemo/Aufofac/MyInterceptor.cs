using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Aufofac
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("执行前");
            invocation.Proceed();
            Console.WriteLine("执行后");
        }
    }
}
