using System.Collections.Generic;

namespace TpvlDataAnalyzer.Model
{
    public class RootData
    {
        public Props props { get; set; }
        public string page { get; set; }
        public Query query { get; set; }
        public string buildId { get; set; }
        public RuntimeConfig runtimeConfig { get; set; }
        public bool isFallback { get; set; }
        public List<int> dynamicIds { get; set; }
        public bool gssp { get; set; }
        public string locale { get; set; }
        public List<string> locales { get; set; }
        public string defaultLocale { get; set; }
        public List<object> scriptLoader { get; set; }
    }
}