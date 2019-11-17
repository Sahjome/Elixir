using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElixirWebService.Controllers
{
    public class soapController : ApiController
    {
        [Route("api/soatp")]
        [HttpPost]
        public HttpResponseMessage NewSoap(Dictionary<string, object> soap)
        {
            int colength = soap["colour"].ToString().Length;
            int deslength = soap["design"].ToString().Length;

            int sumLength = colength + deslength;

            return Request.CreateResponse(sumLength);
        }
    }
}
