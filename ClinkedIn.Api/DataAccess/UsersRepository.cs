using System;
﻿using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.DataAccess
{
    public class UsersRepository
    { 
        static List<User> _users = new List<User>
        {
             new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Josh",
                LastName = "Pantana",
                SentenceStarted = DateTime.Now,
                SentenceLength = 1,
                Specialty = Specialty.Smuggler,
                InterestList = new List<string>{
                    "Kitchenaid Mixers", "Waterballoon Fights", "Bonnie Rait Tribute bands", "Pig Latin",
                },

            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Heath",
                LastName = "Moore",
                SentenceStarted = DateTime.Now,
                SentenceLength = 3,
                Specialty = Specialty.Haircutting,
                InterestList = new List<string>{
                    "Batman Ties", "Yorkshire Terriors", "Baking", "Vintage Lunchboxes",
                },

            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Jeressia",
                LastName = "Williamson",
                SentenceStarted = DateTime.Now,
                SentenceLength = 2,
                Specialty = Specialty.Hitman,
                InterestList = new List<string>{
                    "poker", "Zombie Movies", "Nascar", "Ancient Aliens",
                },
            },
        };

        internal ActionResult<User> GetById(Guid id)
        {
            var user = _users.FirstOrDefault(c => c.Id == id);
            return user;
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
