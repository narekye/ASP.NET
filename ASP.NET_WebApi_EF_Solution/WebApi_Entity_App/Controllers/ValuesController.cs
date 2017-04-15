using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using WebApi_Entity_App.Database;
namespace WebApi_Entity_App.Controllers
{

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
