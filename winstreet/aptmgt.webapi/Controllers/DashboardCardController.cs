using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aptmgt.entity.impl;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webapi.Controllers
{
    [Route("api/[controller]")]
    public class DashboardCardController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get(string cardId)
        {
            DashboardCard aptNameCard = new DashboardCard(cardId);
            return Json(aptNameCard); 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
