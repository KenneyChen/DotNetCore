using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02ServiceDemo.Services.Impl
{
    public class AutofacTestServiceImpl : IAutofacTestService
    {
        public void Test()
        {
            Console.WriteLine("AutofacTestServiceImpl.Test");
        }
    }
}
