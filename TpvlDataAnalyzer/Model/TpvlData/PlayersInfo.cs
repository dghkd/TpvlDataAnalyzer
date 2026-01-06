namespace TpvlDataAnalyzer.Model{ 

    public class PlayersInfo
    {
        public int id { get; set; }
        public string position { get; set; }
        public int eventId { get; set; }
        public string jerseyNumber { get; set; }
        public int squadId { get; set; }
        public PersonalInfo personalInfo { get; set; }
        public Squad squad { get; set; }
        public Stats stats { get; set; }
    }

}