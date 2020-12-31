using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalTestApi.Models {
    public class Match {
        public Match () {
            Scores = new HashSet<Score> ();
        }
        public int MatchID { get; set; }

        [DataType (DataType.Date)]
        public DateTime Datetime { get; set; }
        public int Attendance { get; set; }
        public int HomeResTeamID { get; set; }
        public virtual Team HomeRes { get; set; }
        public int AwayResTeamID { get; set; }

        public virtual Team AwayRes { get; set; }
        public int StadiumID { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Result Result { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}