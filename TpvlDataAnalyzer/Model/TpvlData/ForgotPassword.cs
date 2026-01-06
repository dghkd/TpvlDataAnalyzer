namespace TpvlDataAnalyzer.Model{ 

    public class ForgotPassword
    {
        public string title { get; set; }
        public string content { get; set; }
        public string content_1 { get; set; }
        public MainPage MainPage { get; set; }
        public SuccessPage SuccessPage { get; set; }
        public FailedPage FailedPage { get; set; }
        public string btn_ok { get; set; }
    }

}