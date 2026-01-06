namespace TpvlDataAnalyzer.Model{ 

    public class ResetPassword
    {
        public string title { get; set; }
        public MainPage MainPage { get; set; }
        public SuccessPage SuccessPage { get; set; }
        public FailedPage FailedPage { get; set; }
        public string btn_ok { get; set; }
    }

}