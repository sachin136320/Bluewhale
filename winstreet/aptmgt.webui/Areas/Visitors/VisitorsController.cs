using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using aptmgt.webui.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
// For more informatio`n on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Areas.Community.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorsController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public VisitorsController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        } 
        
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] JObject testJObject)
        {
            
            if (testJObject is null)
            {
                throw new System.ArgumentNullException(nameof(testJObject));
            }
            
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");
             
            aptmgt.entity.user.OwnerMaster ownerMaster = new aptmgt.entity.user.OwnerMaster();
            foreach (JProperty property in testJObject.Properties())
            {
                switch(property.Name)
                {
                    case "FirstName":
                        ownerMaster.FirstName = property.Value.ToString();
                        break;
                    case "LastName":
                        ownerMaster.LastName = property.Value.ToString();
                        break;
                    case "FlatID":
                        ownerMaster.FlatID = property.Value.ToString();
                        break;
                    case "FlatNumber":
                        ownerMaster.FlatNumber = property.Value.ToString();
                        break;
                    case "MobileNumber":
                        ownerMaster.MobileNumber = property.Value.ToString();
                        break;
                    case "notes":
                        ownerMaster.Notes = property.Value.ToString();
                        break;
                    case "Occupied":
                        ownerMaster.Occupied = (property.Value.ToString() == "true" ? true : false);
                        break;
                    case "Picture":
                        
                        ownerMaster.Picture = Encoding.ASCII.GetBytes(property.Value.ToString());
            //Encoding.ASCII.GetBytes(value);
                        break;
                    case "QRText":
                        ownerMaster.QRText = property.Value.ToString();
                        break;
                    case "Active":
                        ownerMaster.Active = (property.Value.ToString() == "true" ? true : false);
                        break;
                }
            }
            
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

        //GetVisitorHostDetails
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetVisitorHostDetails(string flatid)
        { 
            //var owner = appDBContext.CommunityFlats.Where(o => o.ResidentID == ownerID).Select(own => own); 
            //return Json(owner); 
            return null;
        }


        [HttpGet]
        public JsonResult Get(string ownerID)
        { 
            var owner = appDBContext.OwnerMaster.Where(o => o.ResidentID == ownerID).Select(own => own); 
            return Json(owner); 
        }

        // GET api/values/5 
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAll()
        {   
            var owners = appDBContext.OwnerMaster
            .Join(
                appDBContext.CommunityBlock,
                owner => owner.FlatID,
                block => block.BlockID,
                (owner, block) => new 
                {
                    flatID = owner.FlatID,
                    blockName = block.Blckname, 
                    email = owner.Email,
                    firstName = owner.FirstName,
                    flatNumber = owner.FlatNumber, 
                    lastName = owner.LastName,
                    mobileNumber = owner.MobileNumber,
                    Notes = owner.Notes,
                    occupied = owner.Occupied,
                    residentid = owner.ResidentID
                }
            )
            .Join(
                appDBContext.CommunityFlats,
                owner => owner.flatNumber,
                flat => flat.FlatID,
                (owner, flat) => new
                {
                    blockID = owner.blockName, 
                    bkID = owner.flatID,
                    email = owner.email,
                    firstName = owner.firstName,
                    flatID = owner.flatNumber,
                    flatNumber = flat.FlatNumber, 
                    lastName = owner.lastName,
                    mobileNumber = owner.mobileNumber,
                    notes = owner.Notes,
                    occupied = owner.occupied,
                    residentid = owner.residentid
                }
            ).Select(own => own);
            return Json(owners); 
        }

    }
}
