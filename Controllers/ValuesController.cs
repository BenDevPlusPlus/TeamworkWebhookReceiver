using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using TeamworkWebhookApi.Models;
using TeamworkWebhookApi.DataProviders;

namespace TeamworkWebhookApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {

        // POST api/values
        [HttpPost]
        public string HookAgency(TeamworkAgency agency)
        {
            var provider = new TeamworkAgencyDataProvider();

            string result = provider.Create(agency);

            return result;
        }
    }
}
