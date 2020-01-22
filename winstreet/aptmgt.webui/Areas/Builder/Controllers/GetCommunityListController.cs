using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using aptmgt.entity.builder;
using aptmgt.webui.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Builder.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetCommunityListController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public GetCommunityListController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        }


        // GET api/values/5
        [HttpGet()]
        public JsonResult Get(string builderID)
        {
            var builder = appDBContext.Builder
                    .Where(condition => condition.BuilderId == builderID).ToList();

            var communityList = appDBContext.CommunityDetails.Where(community => community.BuilderID == builder.FirstOrDefault().BuilderId).Select(comm => new
            {
                CommunityID = comm.CommID,
                CommName = comm.Name
            });
             
            return Json(communityList);
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post(aptmgt.entity.builder.Builder builder)
        {  
            return new JsonResult(builder);
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
