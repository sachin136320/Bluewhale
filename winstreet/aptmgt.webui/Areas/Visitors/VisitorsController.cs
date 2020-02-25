using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using aptmgt.webui.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
// For more informatio`n on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Areas.Community.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorsController : Controller
    {
        private readonly ApplicationDBContext appDBContext;
        private readonly ILogger<VisitorsController> _logger;

        public VisitorsController(ApplicationDBContext applicationDBContext, ILogger<VisitorsController> logger)
        {
            appDBContext = applicationDBContext;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
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


            aptmgt.entity.user.VisitorDetails visitorDetails = new aptmgt.entity.user.VisitorDetails();
            foreach (JProperty property in testJObject.Properties())
            {
                switch (property.Name)
                {
                    case "Name":
                        visitorDetails.Name = property.Value.ToString();
                        break;
                    case "NumberOfVisitor":
                        visitorDetails.NumberOfVisitor = property.Value.ToString();
                        break;
                    case "CommunityID":
                        visitorDetails.CommunityID = property.Value.ToString();
                        break;
                    case "Address":
                        visitorDetails.Address = property.Value.ToString();
                        break;
                    case "MobileNumber":
                        visitorDetails.MobileNumber = property.Value.ToString();
                        break;
                    case "VisitorType":
                        visitorDetails.VisitorType = property.Value.ToString();
                        break;
                    case "ResidentID":
                        visitorDetails.ResidentID = property.Value.ToString();
                        break;
                    case "Picture":
                        visitorDetails.Picture = Encoding.ASCII.GetBytes(property.Value.ToString());
                        break;
                    case "CheckInDate":
                        visitorDetails.CheckInDate = property.Value.ToString();
                        break;
                }
            }

            appDBContext.VisitorDetails.Add(visitorDetails);
            appDBContext.SaveChanges();

            return new JsonResult(visitorDetails);
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
        public JsonResult GetVisitorHostDetails(string flatID)
        {
            var owner = appDBContext.OwnerMaster
                            .Where(o => o.FlatID == flatID)
                            .Select(own => new
                            {
                                Name = own.FirstName + " " + own.LastName,
                                Phone = own.MobileNumber,
                                HostID = own.ResidentID
                            }).FirstOrDefault();
            return Json(owner);
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
        public JsonResult GetAll(string communityID)
        {

            _logger.LogInformation("Community ID: " + communityID);
            var flatList = appDBContext.CommunityFlats
            .Join(
                appDBContext.CommunityBlock,
                flat => flat.BlockID,
                block => block.BlockID,
                (flat, block) => new
                {
                    CommunityID = block.CommunityID,
                    Flat = block.Blckname + " - " + flat.FlatNumber,
                    FlatID = flat.FlatID
                })
                .Where(f => f.CommunityID == communityID)
                .Select(all => all);

            _logger.LogInformation(flatList.ToList().ToString());
            return Json(flatList);

            /* var owners = appDBContext.OwnerMaster
            .Where(com => com.CommunityID == communityID)
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
            */
        }


        [Route("[action]")]
        [HttpGet]
        public JsonResult GetVisitorType()
        {
            var VisitorType = new List<string>();
            VisitorType.Add("Delivery");
            VisitorType.Add("House Service");
            VisitorType.Add("Friend");
            return Json(VisitorType);
        }
    }
}
