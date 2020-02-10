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
    public class TenantMetricsController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public TenantMetricsController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        } 
         
        [HttpGet]
        public JsonResult Get(int ownerID)
        { 
            var owner = appDBContext.OwnerMaster.Where(o => o.ResidentID == ownerID).Select(own => own); 
            return Json(owner); 
        }
 

    }
}
