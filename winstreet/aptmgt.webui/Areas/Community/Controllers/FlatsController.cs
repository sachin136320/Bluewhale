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
    public class FlatsController : Controller
    {
        private readonly ApplicationDBContext appDBContext;

        public FlatsController(ApplicationDBContext applicationDBContext)
        {
            appDBContext = applicationDBContext;

        } 

        [HttpGet]
        public JsonResult Get(string blockID)
        { 
            var flatList = appDBContext.CommunityFlats.Where(block => block.BlockID == blockID).Select(blk => new
            {
                flatID = blk.FlatID,
                flatNumber = blk.FlatNumber,
                floorNumber = blk.FloorNumber
            });

            return Json(flatList);            
        }


        // POST api/values
        [HttpPost]
        public JsonResult Post(aptmgt.entity.community.CommunityFlats communityFlats)
        { 
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.CommunityFlats.Add(communityFlats);
            appDBContext.SaveChanges();

            return new JsonResult(communityFlats); 
        }

        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public JsonResult Update(aptmgt.entity.community.CommunityFlats communityFlats)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Bad Request");

            appDBContext.CommunityFlats.Update(communityFlats); 
            //appDBContext.SaveChanges();

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    appDBContext.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is aptmgt.entity.community.CommunityFlats)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                proposedValues[property] = proposedValue; 
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }


            return new JsonResult(communityFlats);
        }
 
        // DELETE api/values/5
        //[HttpDelete("{id}")]
        [Route("[action]")]
        [HttpGet("{id}")]
        public void Delete(string flatID)
        { 
            appDBContext.CommunityFlats
            .RemoveRange(
                appDBContext.CommunityFlats
                .Where(
                    condition => condition.FlatID == flatID
                )
            );
            appDBContext.SaveChanges();
        }
        
    }
}
