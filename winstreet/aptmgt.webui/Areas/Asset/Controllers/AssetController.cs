using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using aptmgt.entity.assets;
using aptmgt.webui.Data;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

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

        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult New(aptmgt.entity.assets.AssetRequest assetRequest)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");
            //assetRequest.RequestDate = DateTime.Now.ToString();
            appDBContext.AssetRequest.Add(assetRequest);
            appDBContext.SaveChanges();

            return new JsonResult(assetRequest);
        }


        // POST api/values
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAllOpenRequest(string communityID)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetRequest
            .Where(
                asset => asset.CommunityId == communityID &&
                (
                    asset.RequestStatus.ToLower() == "open"
                )
            );

            return new JsonResult(assetList);
        }


        [Route("[action]")]
        [HttpGet]
        public JsonResult ProcureAsset(string communityID, string assetRequestID, string actualCost, string notes)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetRequest
            .SingleOrDefault(
                asset => asset.CommunityId == communityID &&
                asset.AssetRequestId == assetRequestID
            );

            assetList.ProcureDate = DateTime.Now;
            assetList.Notes = notes;
            assetList.RequestStatus = "closed";
            assetList.ProcurementStatus = "procured";
            assetList.ActualCost = actualCost;
            appDBContext.SaveChanges();
            /* 
                        AssetDetails assetDetails = new AssetDetails();
                        assetDetails.Name = assetList.Name;
                        assetDetails.Type = null;
                        assetDetails.Category = null;
                        assetDetails.Description = null;
                        assetDetails.ActualCost = actualCost;
                        assetDetails.Notes = null;
                        assetDetails.InsertDateTime = DateTime.Now;
                        assetDetails.CommunityId = communityID;
                        assetDetails.AssetRequestId = assetRequestID;

                        appDBContext.AssetDetails.Add(assetDetails);
                        appDBContext.SaveChanges();
            */
            return new JsonResult(assetList);
        }

        [Route("[action]")]
        [HttpGet]
        public JsonResult ApproveAsset(string communityID, string assetRequestID, string approve, string notes
        )
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            var assetList = appDBContext.AssetRequest
            .SingleOrDefault(
                asset => asset.CommunityId == communityID &&
                asset.AssetRequestId == assetRequestID
            );
            DateTime approveDate = DateTime.Now;
            if (approve.ToLower().Equals("true"))
            {
                assetList.ApprovalStatus = "approved";
                assetList.ApproveDate = approveDate;
                assetList.Notes = notes;
                assetList.RequestStatus = "open";
            }
            else
            {
                assetList.RequestStatus = "closed";
                assetList.ApprovalStatus = "rejected";
                assetList.Notes = notes;
            }
            appDBContext.SaveChanges();

            return new JsonResult(assetList);

        }

        // POST api/values
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetRecentlyProcuredAsset(string communityID)
        {
            //Get list of all asset which is procured but not 
            //available in assetdetails table.

            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            return GetRecentAssetRequests(communityID);
        }


        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult AddAsset([FromBody] JObject testJObject)
        {

            if (testJObject is null)
            {
                throw new System.ArgumentNullException(nameof(testJObject));
            }

            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");
            
            string communityID = "";

            aptmgt.entity.assets.AssetDetails assetDetails = new aptmgt.entity.assets.AssetDetails();
            aptmgt.entity.assets.ServiceDetails serviceDetails = new aptmgt.entity.assets.ServiceDetails();

            foreach (JProperty property in testJObject.Properties())
            {
                switch (property.Name)
                {
                    case "CommunityID":
                        assetDetails.CommunityId = property.Value.ToString();
                        communityID = property.Value.ToString();
                        serviceDetails.CommunityId = communityID;
                        break;
                    case "AssetRequestID":
                        assetDetails.AssetRequestId = property.Value.ToString();
                        break;
                    case "AssetType":
                        assetDetails.Type = property.Value.ToString();
                        break;
                    case "AssetDescription":
                        assetDetails.Description = property.Value.ToString();
                        break;
                    case "AssetCategory":
                        assetDetails.Category = property.Value.ToString();
                        break;
                    case "Name":
                        assetDetails.Name = property.Value.ToString();
                        break;
                    case "ActualCost":
                        assetDetails.ActualCost = property.Value.ToString();
                        break;
                    case "Notes":
                        assetDetails.Notes = property.Value.ToString();
                        break;
                    case "InsertDateTime":
                        assetDetails.InsertDateTime = DateTime.Now;
                        break;
                    case "RequireService":
                        serviceDetails.RequireServiceFlag = (property.Value.ToString().Equals("yes") ? true: false);
                        break;
                    case "NextServiceDate": 
                        serviceDetails.NextServiceDate = DateTime.Parse(property.Value.ToString());
                        break;
                    case "ServiceFrequency":
                        serviceDetails.ServiceFrequencyinDays = property.Value.ToString();
                        break;
                }
            }
            appDBContext.AssetDetails.Add(assetDetails);
            appDBContext.SaveChanges();

            serviceDetails.AssetId = assetDetails.AssetId;
            serviceDetails.InsertDateTime = DateTime.Now;
            serviceDetails.UpdateDateTime= DateTime.Now;
            appDBContext.ServiceDetails.Add(serviceDetails);
            appDBContext.SaveChanges();
            

            return GetRecentAssetRequests(communityID);
        }


        public JsonResult GetRecentAssetRequests(string communityID)
        {
            var assetrequests = appDBContext.AssetRequest.Where(assetrequest =>
                assetrequest.ProcurementStatus.ToLower() == "procured" &&
                assetrequest.CommunityId == communityID)
            .Where(c => !appDBContext.AssetDetails
                .Select(b => b.AssetRequestId)
                .Contains(c.AssetRequestId)
            ).Select(c => c);
            return new JsonResult(assetrequests); ;
        }
    
    

        [Route("[action]")]
        [HttpGet]
        public JsonResult GetServiceHistory(string communityID, string assetID)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");   

             var servicedetails = appDBContext.ServiceHistory.Where(service => 
                service.CommunityId == communityID && 
                service.AssetId == assetID)
            .Select(c => c);
            
            return new JsonResult(servicedetails); ;
             
        }
    
        [Route("[action]")]
        [HttpPost]
        public JsonResult AddServiceHistory(ServiceHistory serviceHistory)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");   

            var serviceDetail = appDBContext.ServiceDetails.Where(s => s.ServiceDetailID == serviceHistory.ServiceDetailID).SingleOrDefault();
            serviceDetail.LastServiceDoneDate = serviceHistory.ServiceDate;
            serviceDetail.LastServiceNotes = serviceHistory.ServiceNotes;
            appDBContext.ServiceDetails.Update(serviceDetail);
            
            serviceHistory.InsertDateTime = DateTime.Now; 
            appDBContext.ServiceHistory.Add(serviceHistory);
            
            appDBContext.SaveChanges();
            
            return new JsonResult(serviceHistory); ;
             
        }
    
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetServiceDetails(string communityID)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request"); 

            var servicedetails = appDBContext.ServiceDetails
            .Join(
                appDBContext.AssetDetails,
                srvcdetails => srvcdetails.AssetId,
                astdtl => astdtl.AssetId,
                (srvcdetails, astdtl) => new 
                {
                    requireServiceFlag = srvcdetails.RequireServiceFlag,   
                    serviceFrequencyinDays = srvcdetails.ServiceFrequencyinDays,
                    nextServiceDate = srvcdetails.NextServiceDate,
                    lastServiceDoneDate = srvcdetails.LastServiceDoneDate,
                    lastServiceNotes = srvcdetails.LastServiceNotes,
                    name = astdtl.Name,
                    serviceDetailID = srvcdetails.ServiceDetailID,
                    assetid = astdtl.AssetId
                }
            )
            .Select(c => c);

            return new JsonResult(servicedetails);
        }

        [Route("[action]")]
        [HttpPost]
        public JsonResult UpdateServiceDetails(ServiceDetails serviceDetails)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.ServiceDetails.Update(serviceDetails); 
            appDBContext.SaveChanges(); 
 
            return new JsonResult(serviceDetails);
             
        }


    }
}
