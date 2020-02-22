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
        public JsonResult Get(string commID)
        {
            /*
                            
                const [tenantcompliant, setTenantCompliant] = React.useState('');
                const [tenantnoncompliant, setTenantNonCompliant] = React.useState('');
                
                const [agreementsubmitted, setAgreementSubmitted] = React.useState('');
                const [agreementnotsubmitted, setAgreementNotSubmitted] = React.useState('');
                Tenanats.AgreementCopySubmitted

                const [expiringrentagreement, setExpiringRentAgreement] = React.useState('');
                
            */
            var AgreementCopySubmitted = appDBContext.OwnerMaster
            .Where(
                    condition => condition.CommunityID == commID
                )
                .Where(
                    condition => condition.AgreementCopySubmitted == true
                ).Count();

            var AgreementCopyNotSubmitted = appDBContext.OwnerMaster
            .Where(
                    condition => condition.CommunityID == commID
                )
                .Where(
                    condition => condition.AgreementCopySubmitted == false
                ).Count();

            return Json(new
            {
                AgreementCopyNotSubmitted = AgreementCopyNotSubmitted,
                AgreementCopySubmitted = AgreementCopySubmitted
            });
        }


    }
}
