namespace TpvlDataAnalyzer.Model{ 

    public class PlayerRankingPage
    {
        public string title { get; set; }
        public Position position { get; set; }
        public SelectBox select_box { get; set; }
        public string points { get; set; }
        public string rate { get; set; }
        public PlayerStats player_stats { get; set; }
    }

}