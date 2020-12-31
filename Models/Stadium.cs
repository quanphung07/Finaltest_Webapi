using System.Collections.Generic;

namespace FinalTestApi.Models
{
    public class Stadium
    {
        public Stadium()
        {
            Matches=new HashSet<Match>();
        }
        public int StadiumID { get; set; }
        public string StadiumName { get; set; }
        public int Capacity { get; set; }
        public string City{get;set;}
        public virtual Team Team { get; set; }
        public virtual ICollection<Match> Matches { get;set;}
    }
}