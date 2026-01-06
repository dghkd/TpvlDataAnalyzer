using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class I18n
    {
        public List<string> locales { get; set; }
        public string defaultLocale { get; set; }
        public bool localeDetection { get; set; }
    }

}