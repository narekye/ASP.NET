using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi_Entity_App.Database;

namespace WebApi_Entity_App.Controllers
{
    [System.Web.Mvc.RoutePrefix("apidb")]
    public class HomeController : ApiController
    {
        private PlayersContext db = new PlayersContext();

        [System.Web.Http.Route("players")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPlayers()
        {
            List<Player> players = db.Players.ToList();
            return Ok(players);
        }
    }
}
