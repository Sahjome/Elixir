using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElixirWebService.Controllers
{
    public class BestestController : ApiController
    {
        [Route("api/wells")]
        [HttpPost]
        public HttpResponseMessage Trent(string ghost)
        {
            return Request.CreateResponse(ghost);
        }
    }
}
