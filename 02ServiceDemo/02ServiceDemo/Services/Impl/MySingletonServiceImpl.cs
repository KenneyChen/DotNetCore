using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class MySingletonServiceImpl : IMySingletonOrderService
    {
        public void Test()
        {
            Console.WriteLine("调用MySingletonServiceImpl.Create");
        }
    }
}
