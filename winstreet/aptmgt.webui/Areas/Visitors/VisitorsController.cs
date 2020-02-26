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
 
            return Json(flatList);
        }

        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAllVisitor(string communityID)
        { 
            var visitorList = appDBContext.VisitorDetails
                .Where(f => f.CommunityID == communityID)
                .Join(
                appDBContext.OwnerMaster,
                visitor => visitor.CommunityID,
                owner => owner.CommunityID,
                (visitor, owner) => new
                {
                    Name = visitor.Name,
                    Phone = visitor.MobileNumber,
                    HostName = owner.FirstName + " " + owner.LastName,
                    HostPhone = owner.MobileNumber,
                    CheckinDate = visitor.CheckInDate,
                    CheckOutDate = visitor.CheckOutDate,
                    VisitID = visitor.VisitID
                })
                .Select(all => all);
 
            return Json(visitorList);
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

        [Route("[action]")]
        [HttpGet]
        public JsonResult CheckOut(string visitid)
        {
            var visitorList = appDBContext.VisitorDetails
                .Where(f => f.VisitID == visitid).FirstOrDefault();
            visitorList.CheckOutDate = System.DateTime.Now.ToString();

            
            appDBContext.VisitorDetails.Update(visitorList);
            appDBContext.SaveChanges();

            return Json(visitorList.CheckOutDate);
        }

    }
}
