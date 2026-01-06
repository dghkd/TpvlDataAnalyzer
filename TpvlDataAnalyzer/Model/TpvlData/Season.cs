using System; 
namespace TpvlDataAnalyzer.Model{ 

    public class Season
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }

}