using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class OrderServiceImpl : IOrderService
    {
        public void Create()
        {
            Console.WriteLine("调用Create");
        }
    }
}
