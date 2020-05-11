using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class MyScopeOrderServiceImpl : IMyScopeOrderService
    {
        public void Test()
        {
            Console.WriteLine("调用MySingletonServiceImpl.Test");
        }
    }
}
