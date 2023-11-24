using EMR.WebAPI.ehr.models;
using System.Web.Http;

namespace EMR.WebAPI.ehr.services
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/testcors")]
        public IHttpActionResult TestCors()
        {
            ServiceRequestStatus status = new ServiceRequestStatus(true, "CORS TEST SUCCESSFUL");

            return Ok(new { results = status });
        }
    }
}
