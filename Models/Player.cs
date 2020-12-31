using System.Collections.Generic;

namespace FinalTestApi.Models
{
    public class Player
    {
        public Player()
        {
            Scores=new HashSet<Score>();
        }
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Kit { get; set; }
        public string Position{get;set;}
        public string Country{get;set;}
        public string CountryImage{get;set;}
        public int TeamID{get;set;}
        public virtual Team Team{get;set;}
        public string FullName{
            get{return FirstName+" "+LastName;}
        }
        public virtual ICollection<Score> Scores{get;set;}
    }
}