using ClinkedIn.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SentenceStarted { get; set; }
        public DateTime SentenceLength { get; set; }
        public ServicesRepository ServicesOffered { get; set; }
        public InterestsRepository InterestList { get; set; }
        public FriendsRepository MyFriends { get; set; }
        public EnemiesRepository MyEnemies { get; set; }
    }
}
