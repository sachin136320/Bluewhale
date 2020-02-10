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
    public class OwnerController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public OwnerController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        } 
        
        // POST api/values
        [HttpPost]
        public JsonResult Post(aptmgt.entity.user.OwnerMaster ownerMaster)
        { 
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.OwnerMaster.Add(ownerMaster);
            appDBContext.SaveChanges();

            return new JsonResult(ownerMaster); 
        }

        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult Update(aptmgt.entity.user.OwnerMaster ownerMaster)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.OwnerMaster.Update(ownerMaster); 
            appDBContext.SaveChanges();

            return new JsonResult(ownerMaster);
        }
 
        [HttpGet]
        public JsonResult Get(int ownerID)
        { 
            var owner = appDBContext.OwnerMaster.Where(o => o.ResidentID == ownerID).Select(own => own); 
            return Json(owner); 
        }

        // GET api/values/5 
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAll()
        { 
            var owners = appDBContext.OwnerMaster.Select(own => own);
            return Json(owners); 
        }

    }
}
