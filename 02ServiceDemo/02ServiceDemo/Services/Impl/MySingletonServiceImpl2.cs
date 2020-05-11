using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class MySingletonServiceImpl2 : IMySingletonOrderService
    {
        public MySingletonServiceImpl2()
        {
            Console.WriteLine("调用MySingletonServiceImpl2.Create2");
        }

        public void Test()
        {
            Console.WriteLine("调用MySingletonServiceImpl2.Create2");
        }
    }
}
