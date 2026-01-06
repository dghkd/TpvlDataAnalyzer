using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using TpvlDataAnalyzer.Kernel;
using TpvlDataAnalyzer.Model;

namespace TpvlDataAnalyzer.ViewModel
{
    public class MainVM : ObservableObject
    {
        #region Private Member

        private string? _sourceUrl;
        private TpvlDataLoader _dataLoader;

        private List<PlayerInfoVM> _playersList;
        private List<PlayerInfoVM> _sortedPlayersList;
        private List<PlayerInfoVM> _filteredPlayersList;

        #endregion Private Member

        #region Constructor

        public MainVM()
        {
            _sourceUrl = @"https://www.tpvl.tw/player/player-ranking";
            _dataLoader = new TpvlDataLoader();

            _playersList = new List<PlayerInfoVM>();
            _sortedPlayersList = new List<PlayerInfoVM>();
            _filteredPlayersList = new List<PlayerInfoVM>();
            this.PlayersColle = new ObservableCollection<PlayerInfoVM>();
        }

        #endregion Constructor

        #region Publilic Member

        public string? SourceUrl
        {
            get => _sourceUrl;
            set => SetProperty(ref _sourceUrl, value);
        }

        public List<PlayerInfoVM> PlayersList
        {
            get => _playersList;
        }

        public ObservableCollection<PlayerInfoVM> PlayersColle { get; set; }

        #endregion Publilic Member

        #region Command

        public RelayCommand CmdLoadData => new RelayCommand(LoadData);
        public RelayCommand CmdSortByScore => new RelayCommand(() => Sort(PlayerSortCriterion.Score));
        public RelayCommand CmdSortByServesErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.ServesErrorRate));
        public RelayCommand CmdSortBySpikesErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.SpikesErrorRate));
        public RelayCommand CmdSortBySetsErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.SetsErrorRate));
        public RelayCommand CmdSortByBlocksErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.BlocksErrorRate));
        public RelayCommand CmdSortByPassesErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.PassesErrorRate));
        public RelayCommand CmdSortByDefensesErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.DefensesErrorRate));
        public RelayCommand CmdSortByServesCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.ServesCompleteRate));
        public RelayCommand CmdSortBySpikesCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.SpikesCompleteRate));
        public RelayCommand CmdSortBySetsCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.SetsCompleteRate));
        public RelayCommand CmdSortByBlocksCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.BlocksCompleteRate));
        public RelayCommand CmdSortByPassesCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.PassesCompleteRate));
        public RelayCommand CmdSortByDefensesCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.DefensesCompleteRate));
        public RelayCommand CmdSortByServesErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.ServesErrorCount));
        public RelayCommand CmdSortBySpikesErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.SpikesErrorCount));
        public RelayCommand CmdSortBySetsErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.SetsErrorCount));
        public RelayCommand CmdSortByBlocksErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.BlocksErrorCount));
        public RelayCommand CmdSortByPassesErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.PassesErrorCount));
        public RelayCommand CmdSortByDefensesErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.DefensesErrorCount));
        public RelayCommand CmdSortByServesCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.ServesCompleteCount));
        public RelayCommand CmdSortBySpikesCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.SpikesCompleteCount));
        public RelayCommand CmdSortBySetsCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.SetsCompleteCount));
        public RelayCommand CmdSortByBlocksCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.BlocksCompleteCount));
        public RelayCommand CmdSortByPassesCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.PassesCompleteCount));
        public RelayCommand CmdSortByDefensesCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.DefensesCompleteCount));

        public RelayCommand CmdSortByServesTotal => new RelayCommand(() => Sort(PlayerSortCriterion.ServesTotal));
        public RelayCommand CmdSortBySpikesTotal => new RelayCommand(() => Sort(PlayerSortCriterion.SpikesTotal));
        public RelayCommand CmdSortBySetsTotal => new RelayCommand(() => Sort(PlayerSortCriterion.SetsTotal));
        public RelayCommand CmdSortByBlocksTotal => new RelayCommand(() => Sort(PlayerSortCriterion.BlocksTotal));
        public RelayCommand CmdSortByPassesTotal => new RelayCommand(() => Sort(PlayerSortCriterion.PassesTotal));
        public RelayCommand CmdSortByDefensesTotal => new RelayCommand(() => Sort(PlayerSortCriterion.DefensesTotal));
        public RelayCommand CmdSortByAvgScorePerRound => new RelayCommand(() => Sort(PlayerSortCriterion.AvgScorePerRound));
        public RelayCommand CmdSortByAvgSpikesPerRound => new RelayCommand(() => Sort(PlayerSortCriterion.AvgSpikesPerRound));

        public RelayCommand CmdSortByCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.CompleteCount));
        public RelayCommand CmdSOrtByErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.ErrorCount));

        public RelayCommand CmdSortByAttackTotal => new RelayCommand(() => Sort(PlayerSortCriterion.AttackTotal));
        public RelayCommand CmdSortByAttackErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.AttackErrorCount));
        public RelayCommand CmdSortByAttackErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.AttackErrorRate));
        public RelayCommand CmdSortByAttackCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.AttackCompleteCount));
        public RelayCommand CmdSortByAttackCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.AttackCompleteRate));
        public RelayCommand CmdSortByResistanceTotal => new RelayCommand(() => Sort(PlayerSortCriterion.ResistanceTotal));
        public RelayCommand CmdSortByResistanceErrorCount => new RelayCommand(() => Sort(PlayerSortCriterion.ResistanceErrorCount));
        public RelayCommand CmdSortByResistanceErrorRate => new RelayCommand(() => Sort(PlayerSortCriterion.ResistanceErrorRate));
        public RelayCommand CmdSortByResistanceCompleteCount => new RelayCommand(() => Sort(PlayerSortCriterion.ResistanceCompleteCount));
        public RelayCommand CmdSortByResistanceCompleteRate => new RelayCommand(() => Sort(PlayerSortCriterion.ResistanceCompleteRate));

        public RelayCommand CmdShowPlayerFilterDialog => new RelayCommand(() =>
        {
            OnCommandAction(nameof(this.CmdShowPlayerFilterDialog));
        });

        #endregion Command

        #region Event

        public event EventHandler<string>? CommandAction;

        private void OnCommandAction(string cmdKey)
        {
            CommandAction?.Invoke(this, cmdKey);
        }

        #endregion Event

        #region Public Method

        /// <summary>
        /// 讀取並解析資料，將結果存入 PlayersColle 屬性中。
        /// </summary>
        public void LoadData()
        {
            string htmlString = _dataLoader.LoadHtmlString(this.SourceUrl);
            string jsonString = _dataLoader.ParsePlayersInfoJsonString(htmlString);

            RootData? dataRaw = JsonConvert.DeserializeObject<RootData>(jsonString);
            if (dataRaw != null)
            {
                _playersList.Clear();
                foreach (PlayersInfo item in dataRaw.props.pageProps.playersInfo)
                {
                    PlayerInfoVM playerVM = new PlayerInfoVM(item);
                    playerVM.IsFilterSelected = true; // 預設全部選取
                    _playersList.Add(playerVM);
                    _sortedPlayersList.Add(playerVM);
                }

                // 更新 ObservableCollection
                PlayersColle.Clear();
                for (int i = 0; i < _playersList.Count; i++)
                {
                    PlayerInfoVM player = _playersList[i];
                    player.SortRank = i + 1;
                    PlayersColle.Add(player);
                }
            }
            else
            {
                DebugWriteLine("反序列化 JSON 失敗，dataRaw 為 null", nameof(LoadData));
                App.Current.MainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"載入資料失敗:{htmlString}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        /// <summary>
        /// 排序 _playersList 的資料，將結果傳到 _sortedPlayersList，但不影響原始列表。
        /// </summary>
        /// <param name="criterion">指定要根據哪個 Rate 屬性進行排序。</param>
        /// <param name="direction">指定排序方向，預設為降序 (由高到低)。</param>
        public void Sort(PlayerSortCriterion criterion, SortDirection direction = SortDirection.Descending)
        {
            // 檢查原始列表是否為空或 null
            if (_playersList == null || !_playersList.Any())
            {
                _sortedPlayersList = new List<PlayerInfoVM>();
                return;
            }

            // 步驟 1: 建立原始列表的淺拷貝 (Shallow Copy)
            // 確保對排序的修改不會影響 _playersList。
            IEnumerable<PlayerInfoVM> unsortedCopy = _playersList.ToList();

            // 步驟 2: 選擇排序鍵 (使用 SelectRateProperty 函式動態選擇屬性)
            Func<PlayerInfoVM, double> keySelector = SelectRateProperty(criterion);

            // 步驟 3: 執行排序並賦值給 _sortedPlayersList
            _sortedPlayersList.Clear();
            if (direction == SortDirection.Ascending)
            {
                _sortedPlayersList = unsortedCopy.OrderBy(keySelector).ToList();
            }
            else
            {
                // 預設降序 (通常比率排序希望最高的在前面)
                _sortedPlayersList = unsortedCopy.OrderByDescending(keySelector).ToList();
            }

            // 更新 ObservableCollection
            for (int i = 0; i < _sortedPlayersList.Count; i++)
            {
                PlayerInfoVM player = _sortedPlayersList[i];
                player.SortCriterion = criterion;
            }
            UpdateCollectionByFilter();
        }

        /// <summary>
        /// 輔助函式：根據排序標準選擇對應的 PlayerInfoVM Rate 屬性。
        /// </summary>
        private Func<PlayerInfoVM, double> SelectRateProperty(PlayerSortCriterion criterion)
        {
            // 使用 switch-expression 簡化邏輯
            return criterion switch
            {
                PlayerSortCriterion.Score => p => p.ScoreCount,
                PlayerSortCriterion.ServesCompleteRate => p => p.ServesCompleteRate,
                PlayerSortCriterion.ServesAttemptRate => p => p.ServesAttemptRate,
                PlayerSortCriterion.ServesErrorRate => p => p.ServesErrorRate,
                PlayerSortCriterion.ServesTotal => p => p.ServesTotal,

                PlayerSortCriterion.SpikesCompleteRate => p => p.SpikesCompleteRate,
                PlayerSortCriterion.SpikesAttemptRate => p => p.SpikesAttemptRate,
                PlayerSortCriterion.SpikesErrorRate => p => p.SpikesErrorRate,
                PlayerSortCriterion.SpikesTotal => p => p.SpikesTotal,

                PlayerSortCriterion.SetsCompleteRate => p => p.SetsCompleteRate,
                PlayerSortCriterion.SetsAttemptRate => p => p.SetsAttemptRate,
                PlayerSortCriterion.SetsErrorRate => p => p.SetsErrorRate,
                PlayerSortCriterion.SetsTotal => p => p.SetsTotal,

                PlayerSortCriterion.BlocksCompleteRate => p => p.BlocksCompleteRate,
                PlayerSortCriterion.BlocksAttemptRate => p => p.BlocksAttemptRate,
                PlayerSortCriterion.BlocksErrorRate => p => p.BlocksErrorRate,
                PlayerSortCriterion.BlocksTotal => p => p.BlocksTotal,

                PlayerSortCriterion.PassesCompleteRate => p => p.PassesCompleteRate,
                PlayerSortCriterion.PassesAttemptRate => p => p.PassesAttemptRate,
                PlayerSortCriterion.PassesErrorRate => p => p.PassesErrorRate,
                PlayerSortCriterion.PassesTotal => p => p.PassesTotal,

                PlayerSortCriterion.DefensesCompleteRate => p => p.DefensesCompleteRate,
                PlayerSortCriterion.DefensesAttemptRate => p => p.DefensesAttemptRate,
                PlayerSortCriterion.DefensesErrorRate => p => p.DefensesErrorRate,
                PlayerSortCriterion.DefensesTotal => p => p.DefensesTotal,

                PlayerSortCriterion.ServesCompleteCount => p => p.ServesComplete,
                PlayerSortCriterion.ServesAttemptCount => p => p.ServesAttempt,
                PlayerSortCriterion.ServesErrorCount => p => p.ServesError,

                PlayerSortCriterion.SpikesCompleteCount => p => p.SpikesComplete,
                PlayerSortCriterion.SpikesAttemptCount => p => p.SpikesAttempt,
                PlayerSortCriterion.SpikesErrorCount => p => p.SpikesError,

                PlayerSortCriterion.SetsCompleteCount => p => p.SetsComplete,
                PlayerSortCriterion.SetsAttemptCount => p => p.SetsAttempt,
                PlayerSortCriterion.SetsErrorCount => p => p.SetsError,

                PlayerSortCriterion.BlocksCompleteCount => p => p.BlocksComplete,
                PlayerSortCriterion.BlocksAttemptCount => p => p.BlocksAttempt,
                PlayerSortCriterion.BlocksErrorCount => p => p.BlocksError,

                PlayerSortCriterion.PassesCompleteCount => p => p.PassesComplete,
                PlayerSortCriterion.PassesAttemptCount => p => p.PassesAttempt,
                PlayerSortCriterion.PassesErrorCount => p => p.PassesError,

                PlayerSortCriterion.DefensesCompleteCount => p => p.DefensesComplete,
                PlayerSortCriterion.DefensesAttemptCount => p => p.DefensesAttempt,
                PlayerSortCriterion.DefensesErrorCount => p => p.DefensesError,

                PlayerSortCriterion.AvgScorePerRound => p => p.ScoreAvgCountPerRound,
                PlayerSortCriterion.AvgSpikesPerRound => p => p.SpikesAvgCountPerRound,

                PlayerSortCriterion.CompleteCount => p => p.CompleteCount,
                PlayerSortCriterion.ErrorCount => p => p.ErrorCount,

                PlayerSortCriterion.AttackTotal => p => p.AttackTotal,
                PlayerSortCriterion.AttackErrorCount => p => p.AttackError,
                PlayerSortCriterion.AttackErrorRate => p => p.AttackErrorRate,
                PlayerSortCriterion.AttackCompleteCount => p => p.AttackComplete,
                PlayerSortCriterion.AttackCompleteRate => p => p.AttackCompleteRate,
                PlayerSortCriterion.ResistanceTotal => p => p.ResistanceTotal,
                PlayerSortCriterion.ResistanceErrorCount => p => p.ResistanceError,
                PlayerSortCriterion.ResistanceErrorRate => p => p.ResistanceErrorRate,
                PlayerSortCriterion.ResistanceCompleteCount => p => p.ResistanceComplete,
                PlayerSortCriterion.ResistanceCompleteRate => p => p.ResistanceCompleteRate,

                // 如果傳入的列舉值無效，則返回一個不影響排序的預設值
                _ => p => 0.0,
            };
        }

        /// <summary>
        /// 根據篩選器選擇更新球員列表集合
        /// </summary>
        /// <remarks>
        /// 此方法會清除現有集合，並使用排序列表中選擇了篩選器的球員重新填充
        /// 更新後的集合中每個球員的排名將被重新計算
        /// </remarks>
        public void UpdateCollectionByFilter()
        {
            PlayersColle.Clear();
            int i = 1;
            foreach (PlayerInfoVM player in _sortedPlayersList)
            {
                if (player.IsFilterSelected == true)
                {
                    player.SortRank = i++;
                    PlayersColle.Add(player);
                }
            }
        }

        #endregion Public Method

        #region Private Method

        private void DebugWriteLine(string msg, string methodName)
        {
            string log = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] [MainVM] [{methodName}] {msg}";
            System.Diagnostics.Debug.WriteLine(log);
        }

        #endregion Private Method
    }
}