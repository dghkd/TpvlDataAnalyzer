using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class UserConfig
    {
        public I18n i18n { get; set; }
        public string localePath { get; set; }
        public List<string> defaultNS { get; set; }
        public Default @default { get; set; }
    }

}