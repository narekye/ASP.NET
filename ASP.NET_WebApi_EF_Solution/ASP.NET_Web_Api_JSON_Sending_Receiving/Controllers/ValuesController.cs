namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Controllers
{
    using System.Web.Http;
    using Models;

    public class ValuesController : ApiController
    {
        #region Comment
        //// GET api/values
        ////public IEnumerable<string> Get()
        ////{
        ////    return new string[] { "value1", "value2" };
        ////}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{

        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        #endregion Comment
        // you must comment one post method... 

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
