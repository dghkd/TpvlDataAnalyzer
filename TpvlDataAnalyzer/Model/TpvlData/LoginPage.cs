namespace TpvlDataAnalyzer.Model{ 

    public class LoginPage
    {
        public string title { get; set; }
        public string user_account { get; set; }
        public string hint_user_account { get; set; }
        public string email { get; set; }
        public string hint_email { get; set; }
        public string password { get; set; }
        public string hint_password { get; set; }
        public string btn_login { get; set; }
        public string or { get; set; }
        public string signup { get; set; }
        public string forgetpassword { get; set; }
        public string take_action_now { get; set; }
        public string not_member_yet { get; set; }
        public string description_signup { get; set; }
        public string go_to_registration { get; set; }
        public LoginFailed LoginFailed { get; set; }
    }

}