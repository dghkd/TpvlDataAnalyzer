namespace TpvlDataAnalyzer.Model{ 

    public class ContactPage
    {
        public string title { get; set; }
        public string email_subject { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public string placeholder_name { get; set; }
        public string placeholder_phone { get; set; }
        public string placeholder_email { get; set; }
        public string placeholder_message { get; set; }
        public string btn_submit { get; set; }
        public SubmitFailed SubmitFailed { get; set; }
        public string error_required { get; set; }
        public string contact_message { get; set; }
        public string contact_description { get; set; }
        public string contact_email { get; set; }
        public string address { get; set; }
    }

}