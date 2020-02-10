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
    public class BuilderController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public BuilderController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        }


        // GET api/values/5
        [HttpGet()]
        public JsonResult Get(string builderID)
        {
            if (builderID.ToLower().Equals("all"))
            {
                var listofBuilder = appDBContext.Builder.Select(build =>
                              new
                              {
                                  BuilderID = build.BuilderId,
                                  BuilderName = build.Name
                              }).ToList();
                return new JsonResult(listofBuilder);
            }
 
            return Json(appDBContext.Builder
                    .Where(condition => condition.BuilderId == builderID)
                    .Select(build =>
                                new
                                {
                                    BuilderID = build.BuilderId,
                                    BuilderName = build.Name,
                                    Communities = build.Communities
                                }));
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
            if (!ModelState.IsValid)
                return BadRequest("Bad Request");

            appDBContext.Builder.Add(builder);
            appDBContext.SaveChanges();

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
