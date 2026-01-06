using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class NextI18Next
    {
        public InitialI18nStore initialI18nStore { get; set; }
        public string initialLocale { get; set; }
        public List<string> ns { get; set; }
        public UserConfig userConfig { get; set; }
    }

}