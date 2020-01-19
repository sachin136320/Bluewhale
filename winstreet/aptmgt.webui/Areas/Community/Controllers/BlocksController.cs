using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using aptmgt.webui.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Areas.Community.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlocksController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public BlocksController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(aptmgt.entity.community.CommunityBlock communityBlock)
        { 
            if (!ModelState.IsValid)
                return BadRequest("Bad Request");

            appDBContext.CommunityBlock.Add(communityBlock);
            appDBContext.SaveChanges();

            return new JsonResult(communityBlock); 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            Console.WriteLine(value.ToString());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string blockID)
        { 
            appDBContext.CommunityBlock
            .RemoveRange(
                appDBContext.CommunityBlock
                .Where(
                    condition => condition.BlockID == blockID
                )
            );
            appDBContext.SaveChanges();
        }
    }
}
