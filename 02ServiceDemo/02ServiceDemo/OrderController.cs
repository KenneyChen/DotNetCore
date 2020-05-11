using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _02ServiceDemo.Services;
using AutofacLib.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _02ServiceDemo
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IMyScopeOrderService IMyScopeOrderService;

        private IMySingletonOrderService mySingletonOrderService;

        private IMyTansientOrderService myTansientOrderService;

        private IMyScopeOrderService IMyScopeOrderService3 { get; set; }



        public OrderController(IMyScopeOrderService IMyScopeOrderService,
            IMySingletonOrderService mySingletonOrderService,
            IMyTansientOrderService myTansientOrderService
            )
        {
            this.IMyScopeOrderService = IMyScopeOrderService;
            this.mySingletonOrderService = mySingletonOrderService;
            this.myTansientOrderService = myTansientOrderService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(
            [FromServices] IMyScopeOrderService Scope2,
            [FromServices] IMySingletonOrderService singleton2,
            [FromServices] IMyTansientOrderService tansient2
            )
        {


            Console.WriteLine($"Scope2{IMyScopeOrderService.GetHashCode()},{Scope2.GetHashCode()}");
            Console.WriteLine($"Singleton{mySingletonOrderService.GetHashCode()},{singleton2.GetHashCode()}");
            Console.WriteLine($"Tansient{myTansientOrderService.GetHashCode()},{tansient2.GetHashCode()}");
            Console.WriteLine($"IMyScopeOrderService3:{IMyScopeOrderService3.GetHashCode()}");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
