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
            List<User> userList = UsersRepository._users;
            if (userList.Count == 0)
            {
                repo.AddSeedData();
            }
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
                SentenceEnds = user.SentenceEnds,
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

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(UserUpdateCommand user, Guid id)
        {
            var repo = new UsersRepository();

            var userOutline = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var updatedUser = repo.UpdateUser(userOutline, id);
            return updatedUser;
        }

        [HttpPut("{id}/Friends/{friendId}")]
        public ActionResult<List<User>> AddFriend(Guid id, Guid friendId)
        {
            var repo = new UsersRepository();
            var user = repo.GetByIdToAddFriendOrEnemy(id);
            var friendToAdd = repo.GetByIdToAddFriendOrEnemy(friendId);
            var currentFriends = user.MyFriends;
            var reciprocateFriend = friendToAdd.MyFriends;
            currentFriends.Add(friendToAdd);
            reciprocateFriend.Add(user);
            return currentFriends;
        }

        [HttpPut("{id}/Enemies/{enemyId}")]
        public ActionResult<List<User>> AddEnemy(Guid id, Guid enemyId)
        {
            var repo = new UsersRepository();
            var user = repo.GetByIdToAddFriendOrEnemy(id);
            var enemyToAdd = repo.GetByIdToAddFriendOrEnemy(enemyId);
            var currentEnemies = user.MyEnemies;
            var reciprocateEnemy = enemyToAdd.MyEnemies;
            currentEnemies.Add(enemyToAdd);
            reciprocateEnemy.Add(user);
            return currentEnemies;

        }

        [HttpGet("{id}/Sentence")]
        public ActionResult<string> GetSentenceLeft(Guid id)
        {
            var repo = new UsersRepository();
            return repo.DaysLeft(id);

        }

        [HttpGet("interests/{interest}")]
        public ActionResult<IEnumerable<string>> GetByInterests(string interest)
        {
            var repo = new UsersRepository();
            var usersWithInterest = repo.GetUsersByInterests(interest);
            return Ok(usersWithInterest);

        }
    }
}

