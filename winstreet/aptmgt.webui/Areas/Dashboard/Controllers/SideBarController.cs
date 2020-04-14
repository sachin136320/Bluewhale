using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aptmgt.entity.dashboard;
using aptmgt.entity.impl;
using aptmgt.entity.user;
using aptmgt.webui.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aptmgt.webapi.Controllers
{
    [Route("api/[controller]")]
    public class SideBarController : Controller
    {
        private readonly ApplicationDBContext _appDBContext;
        private readonly ILogger<SideBarController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SideBarController(ApplicationDBContext applicationDBContext, ILogger<SideBarController> logger, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _appDBContext = applicationDBContext;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<Sidebar> sideBars = new List<Sidebar>();
            //Geneic Sections
            sideBars.AddRange(Sidebar.GetGenericSections());

            try{            
            
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user!=null){
                var roles = await _userManager.GetRolesAsync(user);


                //Admin Sections
                if (roles.Contains("Admin"))
                    sideBars.AddRange(Sidebar.GetAdminSections());

            }
            }catch(Exception e)
            { 
            }

                return Json(sideBars);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
