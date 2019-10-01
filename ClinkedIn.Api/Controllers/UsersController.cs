using ClinkedIn.Api.DataAccess;
using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Controllers
{
    [Route("api/clinkers")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var repo = new UsersRepository();
            return repo.GetAll();
        }

        [HttpGet("{id}/Friends")]
        public ActionResult<IEnumerable<User>> GetFriends(Guid id)
        {
            var repo = new UsersRepository();
            var friendsList = repo.GetFriends(id);

            return Ok(friendsList);
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetById(Guid id)
        {
            var repo = new UsersRepository();
            return repo.GetById(id);
        }
    }
}

