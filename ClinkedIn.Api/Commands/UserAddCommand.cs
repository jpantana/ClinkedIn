using ClinkedIn.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Api.Commands
{
    public class UserAddCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SentenceEnds { get; set; }
        public Specialty Specialty { get; set; }
        public List<string> InterestList { get; set; }
        
    }
}
