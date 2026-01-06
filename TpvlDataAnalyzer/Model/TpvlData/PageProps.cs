using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class PageProps
    {
        public DefaultOptions defaultOptions { get; set; }
        public List<PlayersInfo> playersInfo { get; set; }
        public NextI18Next _nextI18Next { get; set; }
    }

}