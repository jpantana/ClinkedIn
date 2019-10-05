using ClinkedIn.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SentenceStarted { get; set; }
        public DateTime SentenceEnds { get; set; }
        public Specialty Specialty { get; set; }
        public List<string> InterestList { get; set; }
        public List<User> MyFriends { get; set; }
        public List<User> MyEnemies { get; set; }
    }

    public enum Specialty
    {
        Haircutting,
        Tattoo_Artist,
        Hitman,
        Smuggler,
        Protection,
        Rat,
        Bootlegger,
        Makup_Artist,
    }
}
