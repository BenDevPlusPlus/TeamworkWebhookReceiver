using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TeamworkToAce.Models;
using TeamworkToAce.DataProviders;

namespace TeamworkToAce.Controllers
{
    public class ValuesController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/values
        [HttpGet]
        public string HookAgency(TeamworkAgencyRequest request)
        {
            var provider = new TeamworkAgencyDataProvider();

            string result = provider.Create(request.Project);

            return result;
        }
/*
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }*/
    }
}
