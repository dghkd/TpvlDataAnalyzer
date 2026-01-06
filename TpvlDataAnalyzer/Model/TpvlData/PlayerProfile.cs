namespace TpvlDataAnalyzer.Model{ 

    public class PlayerProfile
    {
        public string title { get; set; }
        public string careerStats { get; set; }
        public string attackPoints { get; set; }
        public string blockPoints { get; set; }
        public string servePoints { get; set; }
        public string passes { get; set; }
        public string defenses { get; set; }
        public string sets { get; set; }
        public string totalPoints { get; set; }
        public string squad { get; set; }
        public string position { get; set; }
        public string age { get; set; }
        public string dob { get; set; }
        public string school { get; set; }
        public string experience { get; set; }
        public ActionLabel actionLabel { get; set; }
        public TotalScoreLabel totalScoreLabel { get; set; }
        public string timesUnit { get; set; }
        public string successRateLabel { get; set; }
        public string pointsUnit { get; set; }
        public string squadPlaceHolder { get; set; }
    }

}