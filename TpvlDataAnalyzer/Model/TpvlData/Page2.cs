using Newtonsoft.Json; 
namespace TpvlDataAnalyzer.Model{ 

    public class Page2
    {
        public string first_name { get; set; }
        public string hint_first_name { get; set; }
        public string last_name { get; set; }
        public string hint_last_name { get; set; }
        public string gender { get; set; }
        public string gender_hint { get; set; }
        public string male { get; set; }
        public string female { get; set; }
        public string birth { get; set; }
        public string hint_birth { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string confirm_agreement { get; set; }
        public string send_verification_code { get; set; }

        [JsonProperty("120_seconds")]
        public string _120_seconds { get; set; }
        public string verification_code { get; set; }
        public string hint_verification_code { get; set; }
        public string didnt_receive_verification_code { get; set; }
        public string verify_code_failed { get; set; }
    }

}