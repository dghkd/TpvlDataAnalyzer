using System.Collections.Generic; 
namespace TpvlDataAnalyzer.Model{ 

    public class Langs
    {
        public Common Common { get; set; }
        public PageNotFound PageNotFound { get; set; }
        public ComingSoon ComingSoon { get; set; }
        public ExpiredToken ExpiredToken { get; set; }
        public MainPage MainPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public NewsDetails NewsDetails { get; set; }
        public ContactPage ContactPage { get; set; }
        public TournamentPage TournamentPage { get; set; }
        public RefereePage RefereePage { get; set; }
        public SignUp SignUp { get; set; }
        public ForgotPassword ForgotPassword { get; set; }
        public ResetPassword ResetPassword { get; set; }
        public ProfileInformation ProfileInformation { get; set; }
        public AccountSettingPage AccountSettingPage { get; set; }
        public VideoPage VideoPage { get; set; }
        public PhotoPage PhotoPage { get; set; }
        public NewsPage NewsPage { get; set; }
        public MatchesList MatchesList { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
        public Filters Filters { get; set; }
        public Schedule Schedule { get; set; }
        public Record Record { get; set; }
        public TeamRanking TeamRanking { get; set; }
        public RefereeIntroduction RefereeIntroduction { get; set; }
        public TeamPage TeamPage { get; set; }
        public PlayerRankingPage PlayerRankingPage { get; set; }
    }

}