using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using aptmgt.entity.assets;
using aptmgt.webui.Data;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webui.Builder.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly ApplicationDBContext appDBContext;
        private readonly ILogger<AssetController> _logger;


        public AssetController(ApplicationDBContext applicationDBContext, ILogger<AssetController> logger)
        {
            appDBContext = applicationDBContext;
            _logger = logger;
        }


        // GET api/values/5
        [HttpGet()]
        public JsonResult Get(string builderID)
        {
            return new JsonResult("Bad Request");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult New(aptmgt.entity.assets.AssetDetails assetDetails)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.AssetDetails.Add(assetDetails);
            appDBContext.SaveChanges();

            return new JsonResult(assetDetails);
        }


        // POST api/values
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAllOpenRequest(string communityID)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetDetails
            .Where(
                asset => asset.CommunityId == communityID &&
                (
                    asset.RequestStatus.ToLower() != "approved" ||
                    asset.RequestStatus.ToLower() != "rejected"
                )
            );

            return new JsonResult(assetList);
        }


        [Route("[action]")]
        [HttpGet]
        public JsonResult ProcureAsset(string communityID, string assetID, string cost, string notes)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetDetails
            .SingleOrDefault(
                asset => asset.CommunityId == communityID &&
                asset.AssetId == assetID
            );

            assetList.AssetProcureDate = DateTime.Now;
            assetList.Cost = cost;
            assetList.Notes = notes;
            assetList.RequestStatus = "Completed";
            assetList.AssestStatus = "Procured";
            appDBContext.SaveChanges();

            return new JsonResult(assetList);
        }

        [Route("[action]")]
        [HttpGet]
        public JsonResult ApproveAsset(string communityID, string assetID, string approve, string notes
        )
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetDetails
            .SingleOrDefault(
                asset => asset.CommunityId == communityID &&
                asset.AssetId == assetID
            );
            DateTime approveDate = DateTime.Now;
            if (approve.ToLower().Equals("true"))
            {
                assetList.AssetApproveDate = approveDate;
                assetList.Notes = notes;
                assetList.RequestStatus = "In Progress";
                assetList.AssestStatus = "Approved";
            }
            else
            {
                assetList.RequestStatus = "Rejected";
                assetList.AssestStatus = "Cancelled";
            }
            appDBContext.SaveChanges();

            return new JsonResult(assetList);

        }
    }
}
