namespace FinalTestApi.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int MatchID { get; set; }
        public virtual Match Match { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}