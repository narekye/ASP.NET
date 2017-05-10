namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Controllers
{
    using System.Web.Http;
    using Models;

    public class ValuesController : ApiController
    {
        public IHttpActionResult Post([FromUri]Person p)
        {
            if (ModelState.IsValid)
                return Ok("OK");
            return BadRequest("Please verify your data....!");
        }

        public IHttpActionResult PostPerson([FromBody] Person p)
        {
            if (ModelState.IsValid)
                return Ok("From body ok");
            return NotFound();
        }
    }
}
