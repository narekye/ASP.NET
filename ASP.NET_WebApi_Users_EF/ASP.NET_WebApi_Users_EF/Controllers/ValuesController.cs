namespace ASP.NET_WebApi_Users_EF.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Database;

    public class ValuesController : ApiController
    {
        private static User _loggedUser;
        private UsersContext db = new UsersContext();

        [HttpPost]
        public IHttpActionResult GetAllUsers([FromUri]User urluser)
        {
            if (urluser.Name == "admin" && urluser.RoleId == 1)
            {
                _loggedUser = urluser;
                var users = from user in db.Users
                            join role in db.Roles on user.RoleId equals role.RoleId
                            select new { user.Name, user.SurName, role.Description };
                return Ok(users);
            }
            return BadRequest("You don't have permission to access this page...");
        }

        [HttpPut]
        public IHttpActionResult PutUser([FromUri] User user)
        {
            if (ReferenceEquals(_loggedUser, null)) return BadRequest("Please sign in to continue...");
            if (!ModelState.IsValid)
                return BadRequest("Verify info");

            user.RoleId = 2;
            db.Users.Add(user);
            db.SaveChanges();
            return Ok("User added to database");
        }
        [HttpGet]
        [Route("api/values/logout")]
        public IHttpActionResult Logout()
        {
            if (ReferenceEquals(_loggedUser, null)) return BadRequest("Please sign in for sign out....");
            _loggedUser = null;
            return Ok("User logged out");
        }
        [HttpGet]
        [Route("api/values/aper")]
        public IHttpActionResult GetSomeData()
        {
            return Ok();
        }
    }
}
