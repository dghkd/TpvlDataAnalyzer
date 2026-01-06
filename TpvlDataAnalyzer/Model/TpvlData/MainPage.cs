namespace TpvlDataAnalyzer.Model{ 

    public class MainPage
    {
        public Title Title { get; set; }
        public HeaderMenu HeaderMenu { get; set; }
        public LoginButton LoginButton { get; set; }
        public LogoutButton LogoutButton { get; set; }
        public ResultsItem ResultsItem { get; set; }
        public InformationItem InformationItem { get; set; }
        public MallItem MallItem { get; set; }
        public AboutItem AboutItem { get; set; }
        public RefereeItem RefereeItem { get; set; }
        public ContainerPage ContainerPage { get; set; }
        public FooterMenu FooterMenu { get; set; }
        public Announcement Announcement { get; set; }
        public Partners Partners { get; set; }
        public Schedule Schedule { get; set; }
        public string email { get; set; }
        public string content { get; set; }
        public string btn_send { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string btn_reset { get; set; }
    }

}