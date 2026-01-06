namespace TpvlDataAnalyzer.Model{ 

    public class TeamRanking
    {
        public string ranking { get; set; }
        public string team { get; set; }
        public string match { get; set; }
        public string matches_won { get; set; }
        public string matches_lost { get; set; }
        public string win_rate { get; set; }
        public string lose_rate { get; set; }
        public string points { get; set; }
        public string score_3_0 { get; set; }
        public string score_3_1 { get; set; }
        public string score_3_2 { get; set; }
        public string score_0_3 { get; set; }
        public string score_1_3 { get; set; }
        public string score_2_3 { get; set; }
        public string sets_won { get; set; }
        public string sets_lost { get; set; }
        public string set_rate { get; set; }
        public string points_scored { get; set; }
        public string points_conceded { get; set; }
        public string points_ratio { get; set; }
        public string games_completed_rate { get; set; }
        public HomePage HomePage { get; set; }
    }

}