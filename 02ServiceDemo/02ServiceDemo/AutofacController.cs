using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutofacLib.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _02ServiceDemo
{
    [Route("api/[controller]")]
    public class AutofacController : Controller
    {
        private readonly IAutofacDemotService autofacDemotService;

        public IAutofacDemotService autofacDemotService2 { get; set; }

        public AutofacController(IAutofacDemotService autofacDemotService)
        {
            this.autofacDemotService = autofacDemotService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            autofacDemotService.Test();
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
