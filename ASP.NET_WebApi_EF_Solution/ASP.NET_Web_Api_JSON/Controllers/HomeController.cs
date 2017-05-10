using System.Web.Http;

namespace ASP.NET_Web_Api_JSON.Controllers
{

    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("value")]
        public IHttpActionResult GetSomeData()
        {
            return this.Ok(new[]
            {
                "Hello"
            });
        }
    }
}
