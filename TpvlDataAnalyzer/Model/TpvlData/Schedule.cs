using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class Schedule
    {
        public string title { get; set; }
        public string full_schedule { get; set; }
        public CompetitionData CompetitionData { get; set; }
        public PlayerData PlayerData { get; set; }
        public string allMonths { get; set; }
        public string allYears { get; set; }
        public string allTeams { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string teams { get; set; }
        public string newest { get; set; }
        public string oldest { get; set; }
        public string future { get; set; }
        public string result { get; set; }
        public string live { get; set; }
        public string home { get; set; }
        public string away { get; set; }
        public Date date { get; set; }
        public MonthList month_list { get; set; }
        public string buy_ticket { get; set; }
        public string review { get; set; }
        public string record { get; set; }
    }

}