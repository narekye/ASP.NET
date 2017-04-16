namespace ASP.NET_WebApi_Users_EF.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Database;

    public class ValuesController : ApiController
    {
        private static User _loggedUser = null;
        private UsersContext db = new UsersContext();
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var users = from user in db.Users
                        join role in db.Roles on user.RoleId equals role.RoleId
                        select new { user.Name, user.SurName, role.Description };
            return Ok(users);
        }
        [HttpPut]
        public IHttpActionResult PutUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Verify info");

            user.RoleId = 2;
            db.Users.Add(user);
            db.SaveChanges();
            return Ok("User added to database");
        }

        [HttpPost]
        public IHttpActionResult PostLogin([FromUri]User user)
        {
            if (!ModelState.IsValid) return NotFound();
            if (db.Users.Contains(user))
                _loggedUser = user;
            return Ok();
        }

        [HttpGet]
        [Route("Info")]
        public IHttpActionResult GetInfoAboutUser()
        {
            return Ok(_loggedUser);
        }
        
    }
}
