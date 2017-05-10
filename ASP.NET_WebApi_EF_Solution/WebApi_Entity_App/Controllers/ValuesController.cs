namespace WebApi_Entity_App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Database;

    public class ValuesController : ApiController, IController
    {
        private PlayersContext db = new PlayersContext();

        public void Execute(RequestContext requestContext)
        {

        }

        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
