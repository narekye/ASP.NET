using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi_Entity_App.Database;

namespace WebApi_Entity_App.Controllers
{
    
    public class ValuesController : ApiController,IController
    {
        private PlayersContext db = new PlayersContext();
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
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
        }

        
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPlayers()
        {
            var players = db.Players.ToList();
            return Ok(players);
        }

        public void Execute(RequestContext requestContext)
        {
            
        }
    }
}
