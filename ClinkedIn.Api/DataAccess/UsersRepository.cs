using System;
﻿using ClinkedIn.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClinkedIn.Api.DataAccess
{
    public class UsersRepository
    {
        static List<User> _users = new List<User>();

        public UsersRepository()
        {
            var JoshPantana = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Josh",
                LastName = "Pantana",
                SentenceStarted = DateTime.Now,
                SentenceLength = 1,
                Specialty = Specialty.Smuggler,
                InterestList = new List<string> {
                    "Kitchenaid Mixers", "Waterballoon Fights", "Bonnie Rait Tribute bands", "Pig Latin",
                },
                MyFriends = new List<User>(),
                MyEnemies = new List<User>()
            };

            var JeressiaWilliamson = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Jeressia",
                LastName = "Williamson",
                SentenceStarted = DateTime.Now,
                SentenceLength = 2,
                Specialty = Specialty.Hitman,
                InterestList = new List<string> {
                    "poker", "Zombie Movies", "Nascar", "Ancient Aliens",
                },
                MyFriends = new List<User>(),
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };

            var AmyWinehouse = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Amy",
                LastName = "Winehouse",
                SentenceStarted = DateTime.Now,
                SentenceLength = 4,
                Specialty = Specialty.Makup_Artist,
                InterestList = new List<string> {
                    "singing", "rehab", "smoking cigarettes",
                },
                MyFriends = new List<User>
                {
                    JoshPantana
                },
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };


            var HeathMoore = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Heath",
                LastName = "Moore",
                SentenceStarted = DateTime.Now,
                SentenceLength = 3,
                Specialty = Specialty.Haircutting,
                InterestList = new List<string> {
                    "Batman Ties", "Yorkshire Terriors", "Baking", "Vintage Lunchboxes",
                },
                MyFriends = new List<User>
                {
                    JoshPantana
                },
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };


            var TedBundy = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Ted",
                LastName = "Bundy",
                SentenceStarted = DateTime.Now,
                SentenceLength = 1,
                Specialty = Specialty.Haircutting,
                InterestList = new List<string> {
                    "dancing"
                },
                MyFriends = new List<User>
                {
                    JoshPantana
                },
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };

            var JeffreyDahmer = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Jeffrey",
                LastName = "Dahmer",
                SentenceStarted = DateTime.Now,
                SentenceLength = 1,
                Specialty = Specialty.Haircutting,
                InterestList = new List<string> {
                    "dancing"
                },
                MyFriends = new List<User>
                {
                JoshPantana
                },
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };

            var BritneySpears = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Britney",
                LastName = "Spears",
                SentenceStarted = DateTime.Now,
                SentenceLength = 1,
                Specialty = Specialty.Haircutting,
                InterestList = new List<string> {
                    "dancing"
                },
                MyFriends = new List<User>
                {
                    JoshPantana
                },
                MyEnemies = new List<User>
                {
                    JoshPantana
                }
            };



            _users.Add(JoshPantana);
            _users.Add(HeathMoore);
            _users.Add(JeressiaWilliamson);
            _users.Add(AmyWinehouse);
            _users.Add(BritneySpears);
            _users.Add(JeffreyDahmer);
            _users.Add(TedBundy);

        }





        public List<User> GetAll()
        {
            return _users;
        }


        public ActionResult<List<User>> CreateNewUser(User user)
        {
            _users.Add(user);
            return _users;
        }

        internal ActionResult<User> GetById(Guid id)
        {
            var user = _users.FirstOrDefault(clinker => clinker.Id == id);
            return user;
        }

        public List<User> GetFriends(Guid id)
        {
            var user = _users.FirstOrDefault(thisUser => thisUser.Id == id);
            var friendsList = user.MyFriends;
            return friendsList;
        }

        internal List<User> GetEnemies(Guid id)
        {
            var user = _users.FirstOrDefault(clinker => clinker.Id == id);
            var enemiesList = user.MyEnemies;
            return enemiesList;
        }

        public IEnumerable<string> GetUsersByInterests(string interest)
        {
            Regex pattern = new Regex($@"\b{interest.ToLower()}\b");
            var usersWithInterest = new List<User>();
            foreach(User user in _users)
            {
                foreach(string userInterest in user.InterestList)
                {
                    if (pattern.IsMatch(userInterest.ToLower()))
                    {
                        usersWithInterest.Add(user);
                        break;
                    }
                }
            }
            var usersNames = usersWithInterest.Select(x => $"{x.FirstName} {x.LastName}");
            return usersNames;
        }

    }
}
