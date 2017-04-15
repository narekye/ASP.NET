using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi_Entity_App.Database;
using Json;

namespace WebApi_Entity_App.Controllers
{

    public class ValuesController : ApiController, IController
    {
        private PlayersContext db = new PlayersContext();
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
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
