namespace TpvlDataAnalyzer.Model{ 

    public class SignUp
    {
        public string title { get; set; }
        public Introduction Introduction { get; set; }
        public Page1 Page1 { get; set; }
        public Page2 Page2 { get; set; }
        public Page3 Page3 { get; set; }
        public Page4 Page4 { get; set; }
        public FailedPage FailedPage { get; set; }
        public string successful_toast { get; set; }
        public string verify_now { get; set; }
        public string btn_back { get; set; }
        public string btn_next { get; set; }
        public string btn_confirm { get; set; }
        public string btn_cancel { get; set; }
        public string btn_goto_login { get; set; }
    }

}