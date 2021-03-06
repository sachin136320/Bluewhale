﻿using System;
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
    public class CommunityController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public CommunityController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        }
        // GET: api/values
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        //[HttpGet("{id}")]
        [HttpGet]
        public JsonResult Get(string commID)
        { 
            var communityList = appDBContext.CommunityBlock.Where(community => community.CommunityID == commID).Select(comm => new
            {
                CommBlockID = comm.BlockID,
                BlockName = comm.Blckname,
                numberOfFlats = comm.NumberofFlats,
                numberOfFloors = comm.NumberofFloors
            });

            return Json(communityList); 
        }
 
        [Route("[action]")]
        [HttpGet]
        public JsonResult GetAllCommunities()
        { 
            var communityList = appDBContext.CommunityDetails.Select(comm => new
            {
                CommID = comm.CommID,
                Name = comm.Name
            });

            return Json(communityList); 
        }

        [Route("[action]")]
        [HttpGet]
        public JsonResult GetCommunityDetail(string commID)
        { 
            var communityList = appDBContext.CommunityDetails.Where(community => community.CommID == commID).Select(comm => new
            {
                CommID = comm.CommID,
                Name = comm.Name,
                Address = comm.Address,
                State = comm.State,
                City = comm.City,
                Pincode = comm.Pincode
            });

            return Json(communityList); 
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(aptmgt.entity.community.CommunityDetails communityDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Request");

            appDBContext.CommunityDetails.Add(communityDetails);
            appDBContext.SaveChanges();

            return new JsonResult(communityDetails);
        }
 
    }
}
