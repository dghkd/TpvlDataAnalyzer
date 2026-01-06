using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpvlDataAnalyzer.ViewModel
{
    public class PlayerFilterDialogVM : ObservableObject
    {
        #region Private Member

        private List<PlayerInfoVM> _playerList;

        #endregion Private Member

        #region Constructor

        public PlayerFilterDialogVM(List<PlayerInfoVM> list)
        {
            _playerList = list;
            Init();
        }

        public PlayerFilterDialogVM()
        {
            Init();
        }

        #endregion Constructor

        #region Command

        public RelayCommand CmdSelectAllPlayers => new RelayCommand(SelectAll);

        public RelayCommand CmdClearAllPlayers => new RelayCommand(ClearAll);

        public RelayCommand CmdReverseSelection => new RelayCommand(ReverseSelection);

        public RelayCommand<string> CmdSelectBySquadName => new RelayCommand<string>(SelectBySquadName);

        public RelayCommand<string> CmdSelectByPosition => new RelayCommand<string>(SelectByPosition);

        #endregion Command

        #region Public Member

        public bool IsFilterOnCurrent { get; set; }
        public ObservableCollection<PlayerGroupVM> GroupColle { get; set; }
        public ObservableCollection<string> SquadNameColle { get; set; }
        public ObservableCollection<string> PositionColle { get; set; }

        public ObservableCollection<PlayerInfoVM> PlayersColle { get; set; }

        #endregion Public Member

        #region PubLic Method

        /// <summary>
        /// 選取所有球員
        /// </summary>
        public void SelectAll()
        {
            foreach (PlayerInfoVM player in _playerList)
            {
                player.IsFilterSelected = true;
            }
        }

        /// <summary>
        /// 清除所有選取的球員
        /// </summary>
        public void ClearAll()
        {
            foreach (PlayerInfoVM player in _playerList)
            {
                player.IsFilterSelected = false;
            }
        }

        /// <summary>
        /// 反轉目前選取的球員
        /// </summary>
        public void ReverseSelection()
        {
            foreach (PlayerInfoVM player in _playerList)
            {
                player.IsFilterSelected = !player.IsFilterSelected;
            }
        }

        /// <summary>
        /// 依隊伍名稱選取球員
        /// </summary>
        /// <param name="squadName">指定的隊伍名稱</param>
        public void SelectBySquadName(string? squadName)
        {
            //取得目前已選取的球員清單（如果啟用篩選）
            List<PlayerInfoVM> selectedPlayers = new List<PlayerInfoVM>();
            selectedPlayers = this.IsFilterOnCurrent ? GetSelectedPlayers() : new List<PlayerInfoVM>(_playerList);

            foreach (PlayerInfoVM player in selectedPlayers)
            {
                if (player.Squad == squadName)
                {
                    player.IsFilterSelected = true;
                }
            }
        }

        /// <summary>
        /// 依位置選取球員
        /// </summary>
        /// <param name="position">指定的位置</param>
        public void SelectByPosition(string? position)
        {
            //取得目前已選取的球員清單（如果啟用篩選）
            List<PlayerInfoVM> selectedPlayers = new List<PlayerInfoVM>();
            selectedPlayers = this.IsFilterOnCurrent ? GetSelectedPlayers() : new List<PlayerInfoVM>(_playerList);

            foreach (PlayerInfoVM player in selectedPlayers)
            {
                if (player.PositionText == position)
                {
                    player.IsFilterSelected = true;
                }
            }
        }

        /// <summary>
        /// 取得目前已選取的球員清單
        /// </summary>
        /// <param name="isReset">是否要重設選取狀態</param>
        /// <returns>
        /// 回傳目前已選取的球員清單
        /// 如果 isReset 為 true，則會將選取狀態重設為未選取
        /// </returns>
        public List<PlayerInfoVM> GetSelectedPlayers(bool isReset = true)
        {
            List<PlayerInfoVM> selectedPlayers = new List<PlayerInfoVM>();
            foreach (PlayerInfoVM player in _playerList)
            {
                if (player.IsFilterSelected == true)
                {
                    selectedPlayers.Add(player);
                    if (isReset)
                        player.IsFilterSelected = false;
                }
            }
            return selectedPlayers;
        }

        #endregion PubLic Method

        #region Private Method

        private void Init()
        {
            if (_playerList == null)
            {
                _playerList = new List<PlayerInfoVM>();
            }

            this.IsFilterOnCurrent = false;

            this.PlayersColle = new ObservableCollection<PlayerInfoVM>(_playerList);
            this.GroupColle = new ObservableCollection<PlayerGroupVM>();
            this.SquadNameColle = new ObservableCollection<string>();
            this.PositionColle = new ObservableCollection<string>();

            InitGroupColle();
            InitSquadNameColle();
            InitPositionColle();
        }

        private void InitGroupColle()
        {
            Dictionary<string, List<PlayerInfoVM>> groupDict = new Dictionary<string, List<PlayerInfoVM>>();

            //依據隊伍分組
            foreach (PlayerInfoVM item in _playerList)
            {
                if (item.Squad == null) continue;

                //檢查是否已存在該隊伍名稱
                if (groupDict.TryGetValue(item.Squad, out List<PlayerInfoVM>? value))
                {
                    value.Add(item);
                }
                else if (!string.IsNullOrEmpty(item.Squad))
                {
                    //新增隊伍
                    groupDict[item.Squad] = new List<PlayerInfoVM>() { item };
                }
            }

            //轉換為 ObservableCollection<PlayerGroupVM>
            foreach (var kvp in groupDict)
            {
                PlayerGroupVM groupVM = new()
                {
                    Name = kvp.Key
                };

                //依球員號碼排序
                List<PlayerInfoVM> sortedList = kvp.Value.OrderBy(p => p.JerseyNumber).ToList();
                foreach (var player in sortedList)
                {
                    groupVM.PlayersColle.Add(player);
                }

                this.GroupColle.Add(groupVM);
            }
        }

        private void InitSquadNameColle()
        {
            var squadNames = _playerList
                .Where(p => !string.IsNullOrEmpty(p.Squad))
                .Select(p => p.Squad)
                .Distinct();
            foreach (var name in squadNames)
            {
                if (!string.IsNullOrEmpty(name))
                    this.SquadNameColle.Add(name);
            }
        }

        private void InitPositionColle()
        {
            var positions = _playerList
                .Where(p => !string.IsNullOrEmpty(p.PositionText))
                .Select(p => p.PositionText)
                .Distinct();
            foreach (var pos in positions)
            {
                if (!string.IsNullOrEmpty(pos))
                    this.PositionColle.Add(pos);
            }
        }

        #endregion Private Method
    }
}