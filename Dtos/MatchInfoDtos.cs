using System;

namespace FinalTestApi.Dtos
{
    public class MatchInfoDtos
    {
        public int MatchID { get; set; }

        public DateTime Datetime { get; set; }
        public int Attendance { get; set; }
        public string HomeName { get; set; }
        public string AwayName{ get; set; }
        public string StadiumName { get; set; }
        public int HomeRes{get;set;}
        public int AwayRes{get;set;}
        public string HomeImage{get;set;}
        public string AwayImage { get; set; }
        
    }
}