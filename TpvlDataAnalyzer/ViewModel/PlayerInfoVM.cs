using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TpvlDataAnalyzer.Model;

namespace TpvlDataAnalyzer.ViewModel
{
    public class PlayerInfoVM : ObservableObject
    {
        #region Private Member

        private PlayersInfo? _model;

        private int _sortRank;
        private bool? _isFilterSelected;

        // Base Info

        private string? _name;
        private string? _squad;
        private string? _position;
        private string? _jerseyNumber;
        private int _matchCount;
        private int _roundCount;
        private int _scoreCount;

        // serves (發球)

        private int _servesTotal;
        private int _servesComplete;
        private double _servesCompleteRate;
        private int _servesAttempt;
        private double _servesAttemptRate;
        private int _servesError;
        private double _servesErrorRate;

        // spikes (攻擊)

        private int _spikesTotal;
        private int _spikesComplete;
        private double _spikesCompleteRate;
        private int _spikesAttempt;
        private double _spikesAttemptRate;
        private int _spikesError;
        private double _spikesErrorRate;

        // sets (舉球)

        private int _setsTotal;
        private int _setsComplete;
        private double _setsCompleteRate;
        private int _setsAttempt;
        private double _setsAttemptRate;
        private int _setsError;
        private double _setsErrorRate;

        // blocks (攔網)

        private int _blocksTotal;
        private int _blocksComplete;
        private double _blocksCompleteRate;
        private int _blocksAttempt;
        private double _blocksAttemptRate;
        private int _blocksError;
        private double _blocksErrorRate;

        // passes (接發)

        private int _passesTotal;
        private int _passesComplete;
        private double _passesCompleteRate;
        private int _passesAttempt;
        private double _passesAttemptRate;
        private int _passesError;
        private double _passesErrorRate;

        // defenses (防守)

        private int _defensesTotal;
        private int _defensesComplete;
        private double _defensesCompleteRate;
        private int _defensesAttempt;
        private double _defensesAttemptRate;
        private int _defensesError;
        private double _defensesErrorRate;

        // Average per round

        private double _scoreAvgCountPerRound;
        private double _servesAvgCountPerRound;
        private double _spikesAvgCountPerRound;
        private double _setsAvgCountPerRound;
        private double _blocksAvgCountPerRound;
        private double _passesAvgCountPerRound;
        private double _defensesAvgCountPerRound;
        private double _servesAvgSuccessPerRound;
        private double _spikesAvgSuccessPerRound;
        private double _setsAvgSuccessPerRound;
        private double _blocksAvgSuccessPerRound;
        private double _passesAvgSuccessPerRound;
        private double _defensesAvgSuccessPerRound;
        private double _servesAvgErrorPerRound;
        private double _spikesAvgErrorPerRound;
        private double _setsAvgErrorPerRound;
        private double _blocksAvgErrorPerRound;
        private double _passesAvgErrorPerRound;
        private double _defensesAvgErrorPerRound;

        // Average per Match

        private double _scoreAvgCountPerMatch;
        //private double _servesAvgCountPerMatch;
        //private double _spikesAvgCountPerMatch;
        //private double _setsAvgCountPerMatch;
        //private double _blocksAvgCountPerMatch;
        //private double _passesAvgCountPerMatch;
        //private double _defensesAvgCountPerMatch;

        // Scoring Contribution

        private int _errorCount;
        private int _completeCount;
        private int _attackTotal;
        private int _attackComplete;
        private double _attackCompleteRate;
        private int _attackAttempt;
        private double _attackAttemptRate;
        private int _attackError;
        private double _attackErrorRate;
        private double _attackAvgCompletePerRound;
        private double _attackAvgErrorPerRound;
        private int _resistanceTotal;
        private int _resistanceComplete;
        private double _resistanceCompleteRate;
        private int _resistanceAttempt;
        private double _resistanceAttemptRate;
        private int _resistanceError;
        private double _resistanceErrorRate;
        private double _resistanceAvgCompletePerRound;
        private double _resistanceAvgErrorPerRound;

        private PlayerSortCriterion _sortCriterion;

        #endregion Private Member

        #region Constructor

        public PlayerInfoVM(PlayersInfo model)
        {
            _model = model;
            Init();
        }

        public PlayerInfoVM()
        {
            _model = null;
            Init();
        }

        #endregion Constructor

        #region Design Time

        /// <summary>
        /// 提供設計時資料給 XAML 設計器使用。
        /// </summary>
        public static PlayerInfoVM DesignInstance
        {
            get
            {
                // 由於這是靜態屬性，它會在設計器讀取時建立一個 PlayerInfoVM 實例。
                // 該實例會呼叫 PlayerInfoVM() 構造函式，進而執行 InitTestData()。
                return new PlayerInfoVM();
            }
        }

        #endregion Design Time

        #region Public Member

        public bool? IsFilterSelected
        {
            get
            {
                return _isFilterSelected;
            }
            set
            {
                SetProperty(ref _isFilterSelected, value);
            }
        }

        public int SortRank
        {
            get
            {
                return _sortRank;
            }
            set
            {
                SetProperty(ref _sortRank, value);
            }
        }

        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string? Squad
        {
            get
            {
                return _squad;
            }
            set
            {
                SetProperty(ref _squad, value);
            }
        }

        public string? Position
        {
            get
            {
                return _position;
            }
            set
            {
                SetProperty(ref _position, value);
            }
        }

        public string? PositionText
        {
            get
            {
                string ret = "";
                const string oh = "OutsideHitter";
                const string op = "OppositeHitter";
                const string mb = "MiddleBlocker";
                const string s = "Setter";
                const string lib = "Libero";

                switch (_position)
                {
                    case oh:
                        ret = "邊線攻擊";
                        break;

                    case op:
                        ret = "舉球對角";
                        break;

                    case mb:
                        ret = "中間攔網";
                        break;

                    case s:
                        ret = "舉球員";
                        break;

                    case lib:
                        ret = "自由球員";
                        break;

                    default:
                        ret = "Unknown";
                        break;
                }

                return ret;
            }
            set
            {
                SetProperty(ref _position, value);
            }
        }

        public int JerseyNumber
        {
            get
            {
                _ = int.TryParse(_jerseyNumber, out int ret);
                return ret;
            }
        }

        public string? JerseyNumberText
        {
            get
            {
                return $"#{_jerseyNumber}";
            }
            set
            {
                SetProperty(ref _jerseyNumber, value);
            }
        }

        public int MatchCount
        {
            get
            {
                return _matchCount;
            }
            set
            {
                SetProperty(ref _matchCount, value);
            }
        }

        public int RoundCount
        {
            get
            {
                return _roundCount;
            }
            set
            {
                SetProperty(ref _roundCount, value);
            }
        }

        public int ScoreCount
        {
            get
            {
                return _scoreCount;
            }
            set
            {
                SetProperty(ref _scoreCount, value);
            }
        }

        public double ScoreAvgCountPerRound
        {
            get
            {
                return _scoreAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _scoreAvgCountPerRound, value);
            }
        }

        public double ScoreAvgCountPerMatch
        {
            get
            {
                return _scoreAvgCountPerMatch;
            }
            set
            {
                SetProperty(ref _scoreAvgCountPerMatch, value);
            }
        }

        public int ServesTotal
        {
            get
            {
                return _servesTotal;
            }
            set
            {
                SetProperty(ref _servesTotal, value);
            }
        }

        public int ServesComplete
        {
            get
            {
                return _servesComplete;
            }
            set
            {
                SetProperty(ref _servesComplete, value);
            }
        }

        public double ServesCompleteRate
        {
            get
            {
                return _servesCompleteRate;
            }
            set
            {
                SetProperty(ref _servesCompleteRate, value);
            }
        }

        public int ServesAttempt
        {
            get
            {
                return _servesAttempt;
            }
            set
            {
                SetProperty(ref _servesAttempt, value);
            }
        }

        public double ServesAttemptRate
        {
            get
            {
                return _servesAttemptRate;
            }
            set
            {
                SetProperty(ref _servesAttemptRate, value);
            }
        }

        public int ServesError
        {
            get
            {
                return _servesError;
            }
            set
            {
                SetProperty(ref _servesError, value);
            }
        }

        public double ServesErrorRate
        {
            get
            {
                return _servesErrorRate;
            }
            set
            {
                SetProperty(ref _servesErrorRate, value);
            }
        }

        public double ServesAvgCountPerRound
        {
            get
            {
                return _servesAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _servesAvgCountPerRound, value);
            }
        }

        public int SpikesTotal
        {
            get
            {
                return _spikesTotal;
            }
            set
            {
                SetProperty(ref _spikesTotal, value);
            }
        }

        public int SpikesComplete
        {
            get
            {
                return _spikesComplete;
            }
            set
            {
                SetProperty(ref _spikesComplete, value);
            }
        }

        public double SpikesCompleteRate
        {
            get
            {
                return _spikesCompleteRate;
            }
            set
            {
                SetProperty(ref _spikesCompleteRate, value);
            }
        }

        public int SpikesAttempt
        {
            get
            {
                return _spikesAttempt;
            }
            set
            {
                SetProperty(ref _spikesAttempt, value);
            }
        }

        public double SpikesAttemptRate
        {
            get
            {
                return _spikesAttemptRate;
            }
            set
            {
                SetProperty(ref _spikesAttemptRate, value);
            }
        }

        public int SpikesError
        {
            get
            {
                return _spikesError;
            }
            set
            {
                SetProperty(ref _spikesError, value);
            }
        }

        public double SpikesErrorRate
        {
            get
            {
                return _spikesErrorRate;
            }
            set
            {
                SetProperty(ref _spikesErrorRate, value);
            }
        }

        public double SpikesAvgCountPerRound
        {
            get
            {
                return _spikesAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _spikesAvgCountPerRound, value);
            }
        }

        public int SetsTotal
        {
            get
            {
                return _setsTotal;
            }
            set
            {
                SetProperty(ref _setsTotal, value);
            }
        }

        public int SetsComplete
        {
            get
            {
                return _setsComplete;
            }
            set
            {
                SetProperty(ref _setsComplete, value);
            }
        }

        public double SetsCompleteRate
        {
            get
            {
                return _setsCompleteRate;
            }
            set
            {
                SetProperty(ref _setsCompleteRate, value);
            }
        }

        public int SetsAttempt
        {
            get
            {
                return _setsAttempt;
            }
            set
            {
                SetProperty(ref _setsAttempt, value);
            }
        }

        public double SetsAttemptRate
        {
            get
            {
                return _setsAttemptRate;
            }
            set
            {
                SetProperty(ref _setsAttemptRate, value);
            }
        }

        public int SetsError
        {
            get
            {
                return _setsError;
            }
            set
            {
                SetProperty(ref _setsError, value);
            }
        }

        public double SetsErrorRate
        {
            get
            {
                return _setsErrorRate;
            }
            set
            {
                SetProperty(ref _setsErrorRate, value);
            }
        }

        public double SetsAvgCountPerRound
        {
            get
            {
                return _setsAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _setsAvgCountPerRound, value);
            }
        }

        public int BlocksTotal
        {
            get
            {
                return _blocksTotal;
            }
            set
            {
                SetProperty(ref _blocksTotal, value);
            }
        }

        public int BlocksComplete
        {
            get
            {
                return _blocksComplete;
            }
            set
            {
                SetProperty(ref _blocksComplete, value);
            }
        }

        public double BlocksCompleteRate
        {
            get
            {
                return _blocksCompleteRate;
            }
            set
            {
                SetProperty(ref _blocksCompleteRate, value);
            }
        }

        public int BlocksAttempt
        {
            get
            {
                return _blocksAttempt;
            }
            set
            {
                SetProperty(ref _blocksAttempt, value);
            }
        }

        public double BlocksAttemptRate
        {
            get
            {
                return _blocksAttemptRate;
            }
            set
            {
                SetProperty(ref _blocksAttemptRate, value);
            }
        }

        public int BlocksError
        {
            get
            {
                return _blocksError;
            }
            set
            {
                SetProperty(ref _blocksError, value);
            }
        }

        public double BlocksErrorRate
        {
            get
            {
                return _blocksErrorRate;
            }
            set
            {
                SetProperty(ref _blocksErrorRate, value);
            }
        }

        public double BlocksAvgCountPerRound
        {
            get
            {
                return _blocksAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _blocksAvgCountPerRound, value);
            }
        }

        public int PassesTotal
        {
            get
            {
                return _passesTotal;
            }
            set
            {
                SetProperty(ref _passesTotal, value);
            }
        }

        public int PassesComplete
        {
            get
            {
                return _passesComplete;
            }
            set
            {
                SetProperty(ref _passesComplete, value);
            }
        }

        public double PassesCompleteRate
        {
            get
            {
                return _passesCompleteRate;
            }
            set
            {
                SetProperty(ref _passesCompleteRate, value);
            }
        }

        public int PassesAttempt
        {
            get
            {
                return _passesAttempt;
            }
            set
            {
                SetProperty(ref _passesAttempt, value);
            }
        }

        public double PassesAttemptRate
        {
            get
            {
                return _passesAttemptRate;
            }
            set
            {
                SetProperty(ref _passesAttemptRate, value);
            }
        }

        public int PassesError
        {
            get
            {
                return _passesError;
            }
            set
            {
                SetProperty(ref _passesError, value);
            }
        }

        public double PassesErrorRate
        {
            get
            {
                return _passesErrorRate;
            }
            set
            {
                SetProperty(ref _passesErrorRate, value);
            }
        }

        public double PassesAvgCountPerRound
        {
            get
            {
                return _passesAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _passesAvgCountPerRound, value);
            }
        }

        public int DefensesTotal
        {
            get
            {
                return _defensesTotal;
            }
            set
            {
                SetProperty(ref _defensesTotal, value);
            }
        }

        public int DefensesComplete
        {
            get
            {
                return _defensesComplete;
            }
            set
            {
                SetProperty(ref _defensesComplete, value);
            }
        }

        public double DefensesCompleteRate
        {
            get
            {
                return _defensesCompleteRate;
            }
            set
            {
                SetProperty(ref _defensesCompleteRate, value);
            }
        }

        public int DefensesAttempt
        {
            get
            {
                return _defensesAttempt;
            }
            set
            {
                SetProperty(ref _defensesAttempt, value);
            }
        }

        public double DefensesAttemptRate
        {
            get
            {
                return _defensesAttemptRate;
            }
            set
            {
                SetProperty(ref _defensesAttemptRate, value);
            }
        }

        public int DefensesError
        {
            get
            {
                return _defensesError;
            }
            set
            {
                SetProperty(ref _defensesError, value);
            }
        }

        public double DefensesErrorRate
        {
            get
            {
                return _defensesErrorRate;
            }
            set
            {
                SetProperty(ref _defensesErrorRate, value);
            }
        }

        public double DefensesAvgCountPerRound
        {
            get
            {
                return _defensesAvgCountPerRound;
            }
            set
            {
                SetProperty(ref _defensesAvgCountPerRound, value);
            }
        }

        public double ServesAvgSuccessPerRound
        {
            get
            {
                return _servesAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _servesAvgSuccessPerRound, value);
            }
        }

        public double SpikesAvgSuccessPerRound
        {
            get
            {
                return _spikesAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _spikesAvgSuccessPerRound, value);
            }
        }

        public double SetsAvgSuccessPerRound
        {
            get
            {
                return _setsAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _setsAvgSuccessPerRound, value);
            }
        }

        public double BlockAvgSuccessPerRound
        {
            get
            {
                return _blocksAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _blocksAvgSuccessPerRound, value);
            }
        }

        public double PassesAvgSuccessPerRound
        {
            get
            {
                return _passesAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _passesAvgSuccessPerRound, value);
            }
        }

        public double DefensesAvgSuccessPerRound
        {
            get
            {
                return _defensesAvgSuccessPerRound;
            }
            set
            {
                SetProperty(ref _defensesAvgSuccessPerRound, value);
            }
        }

        public double ServesAvgErrorPerRound
        {
            get
            {
                return _servesAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _servesAvgErrorPerRound, value);
            }
        }

        public double SpikesAvgErrorPerRound
        {
            get
            {
                return _spikesAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _spikesAvgErrorPerRound, value);
            }
        }

        public double SetsAvgErrorPerRound
        {
            get
            {
                return _setsAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _setsAvgErrorPerRound, value);
            }
        }

        public double BlocksAvgErrorPerRound
        {
            get
            {
                return _blocksAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _blocksAvgErrorPerRound, value);
            }
        }

        public double PassesAvgErrorPerRound
        {
            get
            {
                return _passesAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _passesAvgErrorPerRound, value);
            }
        }

        public double DefensesAvgErrorPerRound
        {
            get
            {
                return _defensesAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _defensesAvgErrorPerRound, value);
            }
        }

        public int ErrorCount
        {
            get
            {
                return _errorCount;
            }
            set
            {
                SetProperty(ref _errorCount, value);
            }
        }

        public int CompleteCount
        {
            get
            {
                return _completeCount;
            }
            set
            {
                SetProperty(ref _completeCount, value);
            }
        }

        public int AttackTotal
        {
            get
            {
                return _attackTotal;
            }
            set
            {
                SetProperty(ref _attackTotal, value);
            }
        }

        public int AttackComplete
        {
            get
            {
                return _attackComplete;
            }
            set
            {
                SetProperty(ref _attackComplete, value);
            }
        }

        public double AttackCompleteRate
        {
            get
            {
                return _attackCompleteRate;
            }
            set
            {
                SetProperty(ref _attackCompleteRate, value);
            }
        }

        public int AttackAttempt
        {
            get
            {
                return _attackAttempt;
            }
            set
            {
                SetProperty(ref _attackAttempt, value);
            }
        }

        public double AttackAttemptRate
        {
            get
            {
                return _attackAttemptRate;
            }
            set
            {
                SetProperty(ref _attackAttemptRate, value);
            }
        }

        public int AttackError
        {
            get
            {
                return _attackError;
            }
            set
            {
                SetProperty(ref _attackError, value);
            }
        }

        public double AttackErrorRate
        {
            get
            {
                return _attackErrorRate;
            }
            set
            {
                SetProperty(ref _attackErrorRate, value);
            }
        }

        public double AttackAvgCompletePerRound
        {
            get
            {
                return _attackAvgCompletePerRound;
            }
            set
            {
                SetProperty(ref _attackAvgCompletePerRound, value);
            }
        }

        public double AttackAvgErrorPerRound
        {
            get
            {
                return _attackAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _attackAvgErrorPerRound, value);
            }
        }

        public int ResistanceTotal
        {
            get
            {
                return _resistanceTotal;
            }
            set
            {
                SetProperty(ref _resistanceTotal, value);
            }
        }

        public int ResistanceComplete
        {
            get
            {
                return _resistanceComplete;
            }
            set
            {
                SetProperty(ref _resistanceComplete, value);
            }
        }

        public double ResistanceCompleteRate
        {
            get
            {
                return _resistanceCompleteRate;
            }
            set
            {
                SetProperty(ref _resistanceCompleteRate, value);
            }
        }

        public int ResistanceAttempt
        {
            get
            {
                return _resistanceAttempt;
            }
            set
            {
                SetProperty(ref _resistanceAttempt, value);
            }
        }

        public double ResistanceAttemptRate
        {
            get
            {
                return _resistanceAttemptRate;
            }
            set
            {
                SetProperty(ref _resistanceAttemptRate, value);
            }
        }

        public int ResistanceError
        {
            get
            {
                return _resistanceError;
            }
            set
            {
                SetProperty(ref _resistanceError, value);
            }
        }

        public double ResistanceErrorRate
        {
            get
            {
                return _resistanceErrorRate;
            }
            set
            {
                SetProperty(ref _resistanceErrorRate, value);
            }
        }

        public double ResistanceAvgCompletePerRound
        {
            get
            {
                return _resistanceAvgCompletePerRound;
            }
            set
            {
                SetProperty(ref _resistanceAvgCompletePerRound, value);
            }
        }

        public double ResistanceAvgErrorPerRound
        {
            get
            {
                return _resistanceAvgErrorPerRound;
            }
            set
            {
                SetProperty(ref _resistanceAvgErrorPerRound, value);
            }
        }

        public PlayerSortCriterion SortCriterion
        {
            get
            {
                return _sortCriterion;
            }

            set
            {
                SetProperty(ref _sortCriterion, value);
            }
        }

        #endregion Public Member

        #region Private Method

        private void Init()
        {
            if (_model != null)
            {
                InitBaseInfo();
                if (_matchCount <= 0)
                {
                    // No match data, skip stats init
                    return;
                }

                InitServes();
                InitSpikes();
                InitSets();
                InitBlocks();
                InitPasses();
                InitDefenses();
                InitContribution();
            }
            else
            {
                InitTestData();
            }
        }

        private void InitBaseInfo()
        {
            if (_model == null)
                return;

            _name = _model.personalInfo != null ? _model.personalInfo.name : "Unknown";
            _squad = _model.squad != null ? _model.squad.name : "Unknown";
            _position = _model.position;
            _jerseyNumber = _model.jerseyNumber;

            if (_model.stats == null)
            {
                return;
            }

            _matchCount = _model.stats.matchCount;
            _roundCount = _model.stats.roundCount;
            _scoreCount = _model.stats.score;
            _scoreAvgCountPerRound = _roundCount > 0 ? (double)_scoreCount / _roundCount : 0.0;
            _scoreAvgCountPerMatch = _matchCount > 0 ? (double)_scoreCount / _matchCount : 0.0;
        }

        private void InitServes()
        {
            if (_model == null)
                return;

            _servesTotal = _model.stats.serves;
            _servesComplete = _model.stats.completedServes;
            _servesCompleteRate = _servesTotal > 0 ? (double)_servesComplete / _servesTotal * 100 : 0.0;
            _servesAttempt = _model.stats.attemptServes;
            _servesAttemptRate = _servesTotal > 0 ? (double)_servesAttempt / _servesTotal * 100 : 0.0;
            _servesError = _model.stats.errorServes;
            _servesErrorRate = _servesTotal > 0 ? (double)_servesError / _servesTotal * 100 : 0.0;
            _servesAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.serves / _model.stats.roundCount : 0.0;
            _servesAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedServes / _model.stats.roundCount : 0.0;
            _servesAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorServes / _model.stats.roundCount : 0.0;
        }

        private void InitSpikes()
        {
            if (_model == null)
                return;

            _spikesTotal = _model.stats.spikes;
            _spikesComplete = _model.stats.completedSpikes;
            _spikesCompleteRate = _spikesTotal > 0 ? (double)_spikesComplete / _spikesTotal * 100 : 0.0;
            _spikesAttempt = _model.stats.attemptSpikes;
            _spikesAttemptRate = _spikesTotal > 0 ? (double)_spikesAttempt / _spikesTotal * 100 : 0.0;
            _spikesError = _model.stats.errorSpikes;
            _spikesErrorRate = _spikesTotal > 0 ? (double)_spikesError / _spikesTotal * 100 : 0.0;
            _spikesAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.spikes / _model.stats.roundCount : 0.0;
            _spikesAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedSpikes / _model.stats.roundCount : 0.0;
            _spikesAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorSpikes / _model.stats.roundCount : 0.0;
        }

        private void InitSets()
        {
            if (_model == null)
                return;

            _setsTotal = _model.stats.sets;
            _setsComplete = _model.stats.completedSets;
            _setsCompleteRate = _setsTotal > 0 ? (double)_setsComplete / _setsTotal * 100 : 0.0;
            _setsAttempt = _model.stats.attemptSets;
            _setsAttemptRate = _setsTotal > 0 ? (double)_setsAttempt / _setsTotal * 100 : 0.0;
            _setsError = _model.stats.errorSets;
            _setsErrorRate = _setsTotal > 0 ? (double)_setsError / _setsTotal * 100 : 0.0;
            _setsAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.sets / _model.stats.roundCount : 0.0;
            _setsAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedSets / _model.stats.roundCount : 0.0;
            _setsAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorSets / _model.stats.roundCount : 0.0;
        }

        private void InitBlocks()
        {
            if (_model == null)
                return;
            _blocksTotal = _model.stats.blocks;
            _blocksComplete = _model.stats.completedBlocks;
            _blocksCompleteRate = _blocksTotal > 0 ? (double)_blocksComplete / _blocksTotal * 100 : 0.0;
            _blocksAttempt = _model.stats.attemptBlocks;
            _blocksAttemptRate = _blocksTotal > 0 ? (double)_blocksAttempt / _blocksTotal * 100 : 0.0;
            _blocksError = _model.stats.errorBlocks;
            _blocksErrorRate = _blocksTotal > 0 ? (double)_blocksError / _blocksTotal * 100 : 0.0;
            _blocksAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.blocks / _model.stats.roundCount : 0.0;
            _blocksAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedBlocks / _model.stats.roundCount : 0.0;
            _blocksAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorBlocks / _model.stats.roundCount : 0.0;
        }

        private void InitPasses()
        {
            if (_model == null)
                return;
            _passesTotal = _model.stats.passes;
            _passesComplete = _model.stats.completedPasses;
            _passesCompleteRate = _passesTotal > 0 ? (double)_passesComplete / _passesTotal * 100 : 0.0;
            _passesAttempt = _model.stats.attemptPasses;
            _passesAttemptRate = _passesTotal > 0 ? (double)_passesAttempt / _passesTotal * 100 : 0.0;
            _passesError = _model.stats.errorPasses;
            _passesErrorRate = _passesTotal > 0 ? (double)_passesError / _passesTotal * 100 : 0.0;
            _passesAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.passes / _model.stats.roundCount : 0.0;
            _passesAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedPasses / _model.stats.roundCount : 0.0;
            _passesAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorPasses / _model.stats.roundCount : 0.0;
        }

        private void InitDefenses()
        {
            if (_model == null)
                return;
            _defensesTotal = _model.stats.defenses;
            _defensesComplete = _model.stats.completedDefenses;
            _defensesCompleteRate = _defensesTotal > 0 ? (double)_defensesComplete / _defensesTotal * 100 : 0.0;
            _defensesAttempt = _model.stats.attemptDefenses;
            _defensesAttemptRate = _defensesTotal > 0 ? (double)_defensesAttempt / _defensesTotal * 100 : 0.0;
            _defensesError = _model.stats.errorDefenses;
            _defensesErrorRate = _defensesTotal > 0 ? (double)_defensesError / _defensesTotal * 100 : 0.0;
            _defensesAvgCountPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.defenses / _model.stats.roundCount : 0.0;
            _defensesAvgSuccessPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.completedDefenses / _model.stats.roundCount : 0.0;
            _defensesAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_model.stats.errorDefenses / _model.stats.roundCount : 0.0;
        }

        private void InitContribution()
        {
            if (_model == null)
                return;
            _errorCount = _model.stats.errorServes + _model.stats.errorSpikes + _model.stats.errorSets + _model.stats.errorBlocks + _model.stats.errorPasses + _model.stats.errorDefenses;
            _completeCount = _model.stats.completedServes + _model.stats.completedSpikes + _model.stats.completedSets + _model.stats.completedBlocks + _model.stats.completedPasses + _model.stats.completedDefenses;

            _attackTotal = _model.stats.serves + _model.stats.spikes + _model.stats.sets;
            _attackAttempt = _model.stats.attemptServes + _model.stats.attemptSpikes + _model.stats.attemptSets;
            _attackComplete = _model.stats.completedServes + _model.stats.completedSpikes + _model.stats.completedSets;
            _attackError = _model.stats.errorServes + _model.stats.errorSpikes + _model.stats.errorSets;
            _attackCompleteRate = _attackTotal > 0 ? (double)_attackComplete / _attackTotal * 100 : 0.0;
            _attackAttemptRate = _attackTotal > 0 ? (double)_attackAttempt / _attackTotal * 100 : 0.0;
            _attackErrorRate = _attackTotal > 0 ? (double)_attackError / _attackTotal * 100 : 0.0;
            _attackAvgCompletePerRound = _model.stats.roundCount > 0 ? (double)_attackComplete / _model.stats.roundCount : 0.0;
            _attackAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_attackError / _model.stats.roundCount : 0.0;

            _resistanceTotal = _model.stats.blocks + _model.stats.passes + _model.stats.defenses;
            _resistanceAttempt = _model.stats.attemptBlocks + _model.stats.attemptPasses + _model.stats.attemptDefenses;
            _resistanceComplete = _model.stats.completedBlocks + _model.stats.completedPasses + _model.stats.completedDefenses;
            _resistanceError = _model.stats.errorBlocks + _model.stats.errorPasses + _model.stats.errorDefenses;
            _resistanceCompleteRate = _resistanceTotal > 0 ? (double)_resistanceComplete / _resistanceTotal * 100 : 0.0;
            _resistanceAttemptRate = _resistanceTotal > 0 ? (double)_resistanceAttempt / _resistanceTotal * 100 : 0.0;
            _resistanceErrorRate = _resistanceTotal > 0 ? (double)_resistanceError / _resistanceTotal * 100 : 0.0;
            _resistanceAvgCompletePerRound = _model.stats.roundCount > 0 ? (double)_resistanceComplete / _model.stats.roundCount : 0.0;
            _resistanceAvgErrorPerRound = _model.stats.roundCount > 0 ? (double)_resistanceError / _model.stats.roundCount : 0.0;
        }

        private void InitTestData()
        {
            _sortRank = 999;

            // 1. Base Info
            // 固定值用於測試
            _name = "測試球員 A";
            _squad = "測試隊伍";
            _position = "OutsideHitter";
            _jerseyNumber = "10";
            _matchCount = 15;
            _roundCount = 60; // 總局數
            _scoreCount = 125;
            _scoreAvgCountPerRound = _roundCount > 0 ? (double)_scoreCount / _roundCount : 0.0;
            _scoreAvgCountPerMatch = _matchCount > 0 ? (double)_scoreCount / _matchCount : 0.0;

            // 定義一個局部函式來填充各項統計數據
            // 使用明確的整數來確保 Rate/Avg 是可預期的固定值
            void PopulateStatsFixed(ref int total, ref int complete, ref double completeRate,
                                    ref int attempt, ref double attemptRate,
                                    ref int error, ref double errorRate,
                                    ref double avgPerRound, ref double avgSuccessPerRound, ref double avgErrorPerRound, int totalValue, int completeValue, int attemptValue, int errorValue)
            {
                total = totalValue;
                complete = completeValue;
                attempt = attemptValue;
                error = errorValue;

                // 計算比率 (Rate)
                completeRate = total > 0 ? (double)complete * 100 / total : 0.0; // 確保除數為 double
                attemptRate = total > 0 ? (double)attempt * 100 / total : 0.0;
                errorRate = total > 0 ? (double)error * 100 / total : 0.0;

                // 計算每局平均數 (Average per round)
                avgPerRound = _roundCount > 0 ? (double)total / _roundCount : 0.0;
                avgSuccessPerRound = _roundCount > 0 ? (double)complete / _roundCount : 0.0;
                avgErrorPerRound = _roundCount > 0 ? (double)error / _roundCount : 0.0;
            }

            // 2. Volleyball Stats (使用易於計算的固定數字)

            // serves (發球)
            // 總數 120, 完成 84, 嘗試 96, 失誤 12
            // 完成率: 84/120 = 0.7 (70.0%)
            // 失誤率: 12/120 = 0.1 (10.0%)
            // Avg/Round: 120 / 60 = 2.0
            PopulateStatsFixed(ref _servesTotal, ref _servesComplete, ref _servesCompleteRate,
                               ref _servesAttempt, ref _servesAttemptRate,
                               ref _servesError, ref _servesErrorRate,
                               ref _servesAvgCountPerRound, ref _servesAvgSuccessPerRound, ref _servesAvgErrorPerRound, 120, 84, 96, 12);

            // spikes (攻擊)
            // 總數 250, 完成 100, 嘗試 200, 失誤 25
            // 完成率: 100/250 = 0.4 (40.0%)
            // 失誤率: 25/250 = 0.1 (10.0%)
            // Avg/Round: 250 / 60 ≈ 4.16666...
            PopulateStatsFixed(ref _spikesTotal, ref _spikesComplete, ref _spikesCompleteRate,
                               ref _spikesAttempt, ref _spikesAttemptRate,
                               ref _spikesError, ref _spikesErrorRate,
                               ref _spikesAvgCountPerRound, ref _spikesAvgSuccessPerRound, ref _spikesAvgErrorPerRound, 250, 100, 200, 25);

            // sets (舉球)
            // 總數 300, 完成 210, 嘗試 240, 失誤 30
            // 完成率: 210/300 = 0.7 (70.0%)
            // 失誤率: 30/300 = 0.1 (10.0%)
            // Avg/Round: 300 / 60 = 5.0
            PopulateStatsFixed(ref _setsTotal, ref _setsComplete, ref _setsCompleteRate,
                               ref _setsAttempt, ref _setsAttemptRate,
                               ref _setsError, ref _setsErrorRate,
                               ref _setsAvgCountPerRound, ref _setsAvgSuccessPerRound, ref _setsAvgErrorPerRound, 300, 210, 240, 30);

            // blocks (攔網)
            // 總數 50, 完成 10, 嘗試 30, 失誤 5
            // 完成率: 10/50 = 0.2 (20.0%)
            // 失誤率: 5/50 = 0.1 (10.0%)
            // Avg/Round: 50 / 60 ≈ 0.83333...
            PopulateStatsFixed(ref _blocksTotal, ref _blocksComplete, ref _blocksCompleteRate,
                               ref _blocksAttempt, ref _blocksAttemptRate,
                               ref _blocksError, ref _blocksErrorRate,
                               ref _blocksAvgCountPerRound, ref _blocksAvgSuccessPerRound, ref _blocksAvgErrorPerRound, 50, 10, 30, 5);

            // passes (接發)
            // 總數 80, 完成 56, 嘗試 64, 失誤 8
            // 完成率: 56/80 = 0.7 (70.0%)
            // 失誤率: 8/80 = 0.1 (10.0%)
            // Avg/Round: 80 / 60 ≈ 1.33333...
            PopulateStatsFixed(ref _passesTotal, ref _passesComplete, ref _passesCompleteRate,
                               ref _passesAttempt, ref _passesAttemptRate,
                               ref _passesError, ref _passesErrorRate,
                               ref _passesAvgCountPerRound, ref _passesAvgSuccessPerRound, ref _passesAvgErrorPerRound, 80, 56, 64, 8);

            // defenses (防守)
            // 總數 100, 完成 60, 嘗試 80, 失誤 10
            // 完成率: 60/100 = 0.6 (60.0%)
            // 失誤率: 10/100 = 0.1 (10.0%)
            // Avg/Round: 100 / 60 ≈ 1.66666...
            PopulateStatsFixed(ref _defensesTotal, ref _defensesComplete, ref _defensesCompleteRate,
                               ref _defensesAttempt, ref _defensesAttemptRate,
                               ref _defensesError, ref _defensesErrorRate,
                               ref _defensesAvgCountPerRound, ref _defensesAvgSuccessPerRound, ref _defensesAvgErrorPerRound, 100, 60, 80, 10);

            // 3. Contribution Stats (合計數據)
            _errorCount = _servesError + _spikesError + _setsError + _blocksError + _passesError + _defensesError;
            _completeCount = _servesComplete + _spikesComplete + _setsComplete + _blocksComplete + _passesComplete + _defensesComplete;

            // attack (進攻) = serves + spikes + sets
            // 總數 120 + 250 + 300 = 670
            // 完成 84 + 100 + 210 = 394
            // 嘗試 96 + 200 + 240 = 536
            // 失誤 12 + 25 + 30 = 67
            // 完成率: 394/670 ≈ 58.80597...
            // 嘗試率: 536/670 ≈ 79.85074...
            // 失誤率: 67/670 ≈ 10.0
            // 平均局失分: 67 / 60 ≈ 1.11666...
            _attackTotal = _servesTotal + _spikesTotal + _setsTotal;
            _attackComplete = _servesComplete + _spikesComplete + _setsComplete;
            _attackAttempt = _servesAttempt + _spikesAttempt + _setsAttempt;
            _attackError = _servesError + _spikesError + _setsError;
            _attackCompleteRate = _attackTotal > 0 ? (double)_attackComplete * 100 / _attackTotal : 0.0;
            _attackAttemptRate = _attackTotal > 0 ? (double)_attackAttempt * 100 / _attackTotal : 0.0;
            _attackErrorRate = _attackTotal > 0 ? (double)_attackError * 100 / _attackTotal : 0.0;
            _attackAvgCompletePerRound = _roundCount > 0 ? (double)_attackComplete / _roundCount : 0.0;
            _attackAvgErrorPerRound = _roundCount > 0 ? (double)_attackError / _roundCount : 0.0;

            // resistance (防守) = blocks + passes + defenses
            // 總數 50 + 80 + 100 = 230
            // 完成 10 + 56 + 60 = 126
            // 嘗試 30 + 64 + 80 = 174
            // 失誤 5 + 8 + 10 = 23
            // 完成率: 126/230 ≈ 54.78260...
            // 嘗試率: 174/230 ≈ 75.65217...
            // 失誤率: 23/230 ≈ 10.0
            // 平均局失分: 23 / 60 ≈ 0.38333...
            _resistanceTotal = _blocksTotal + _passesTotal + _defensesTotal;
            _resistanceComplete = _blocksComplete + _passesComplete + _defensesComplete;
            _resistanceAttempt = _blocksAttempt + _passesAttempt + _defensesAttempt;
            _resistanceError = _blocksError + _passesError + _defensesError;
            _resistanceCompleteRate = _resistanceTotal > 0 ? (double)_resistanceComplete * 100 / _resistanceTotal : 0.0;
            _resistanceAttemptRate = _resistanceTotal > 0 ? (double)_resistanceAttempt * 100 / _resistanceTotal : 0.0;
            _resistanceErrorRate = _resistanceTotal > 0 ? (double)_resistanceError * 100 / _resistanceTotal : 0.0;
            _resistanceAvgCompletePerRound = _roundCount > 0 ? (double)_resistanceComplete / _roundCount : 0.0;
            _resistanceAvgErrorPerRound = _roundCount > 0 ? (double)_resistanceError / _roundCount : 0.0;
        }

        #endregion Private Method
    }
}