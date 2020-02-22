using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using aptmgt.webui.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using aptmgt.entity.facility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Areas.Facility.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public FacilityController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        } 

        // GET api/values/5
        //[HttpGet("{id}")]
        [HttpGet]
        public JsonResult Get(string commID)
        { 
            var facilityList = appDBContext.FacilityMaster.Where(facility => facility.CommunityID == commID).Select(f => new
            {
                FacilityID = f.FacilityMasterID,
                Bookable = f.Bookable,
                FacilityName = f.FacilityName
            });

            return Json(facilityList); 
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post(aptmgt.entity.facility.FacilityMaster facilityMaster)
        { 
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.FacilityMaster.Add(facilityMaster);
            appDBContext.SaveChanges();

            return new JsonResult(facilityMaster); 
        }

        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult Update(aptmgt.entity.facility.FacilityMaster facilityMaster)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.FacilityMaster.Update(facilityMaster); 
            appDBContext.SaveChanges();

            return new JsonResult(facilityMaster);
        }
 
        // DELETE api/values/5
        //[HttpDelete("{id}")] 
        [Route("[action]")]
        [HttpGet("{id}")]
        public void Delete(string facilityID)
        { 
            appDBContext.FacilityMaster
            .RemoveRange(
                appDBContext.FacilityMaster
                .Where(
                    condition => condition.FacilityMasterID == facilityID
                )
            );
            appDBContext.SaveChanges();
        }
        
    }
}
