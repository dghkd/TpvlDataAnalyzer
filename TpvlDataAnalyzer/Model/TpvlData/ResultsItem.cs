using Newtonsoft.Json; 
namespace TpvlDataAnalyzer.Model{ 

    public class ResultsItem
    {
        public string live_record { get; set; }
        public string record { get; set; }

        [JsonProperty("player-introduction")]
        public string playerintroduction { get; set; }

        [JsonProperty("competition-data")]
        public string competitiondata { get; set; }
    }

}