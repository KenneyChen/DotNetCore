using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class MyTransientServiceImpl : IMyTansientOrderService, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine($"对象{this}已经释放成功Test");
        }

        public void Test()
        {
            Console.WriteLine("调用MyTransientServiceImpl,Test");
        }
    }
}
