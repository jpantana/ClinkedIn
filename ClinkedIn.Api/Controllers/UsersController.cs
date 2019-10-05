using ClinkedIn.Api.Commands;
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

        [HttpGet("{id}/Enemies")]
        public ActionResult<IEnumerable<User>> GetEnemies(Guid id)
        {
            var repo = new UsersRepository();
            var enemiesList = repo.GetEnemies(id);

            return Ok(enemiesList);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(Guid id)
        {
            var repo = new UsersRepository();
            return repo.GetById(id);
        }

        [HttpPost]
        public ActionResult<List<User>> CreateUser(UserAddCommand user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                SentenceLength = user.SentenceLength,
                SentenceStarted = DateTime.Now,
                Specialty = user.Specialty,
                InterestList = user.InterestList,
                MyFriends = new List<User>(),
                MyEnemies = new List<User>(),
            };

            var repo = new UsersRepository();
            var myNewUser = repo.CreateNewUser(newUser);
            return Ok(myNewUser);
        }

        [HttpPut("{id}/Friends/{friendId}")]
        public ActionResult<List<User>> AddFriends(Guid id, Guid friendId)
        {
            var repo = new UsersRepository();
            var user = repo.GetByIdToAddFriend(id);
            var friendToAdd = repo.GetByIdToAddFriend(friendId);
            var currentFriends = user.MyFriends;
            currentFriends.Add(friendToAdd);
            return currentFriends;
        }
    }
}

