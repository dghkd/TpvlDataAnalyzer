using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpvlDataAnalyzer.ViewModel
{
    public class PlayerGroupVM : ObservableObject
    {
        #region Constructor

        public PlayerGroupVM()
        {
            this.Name = "";
            this.PlayersColle = new ObservableCollection<PlayerInfoVM>();
        }

        #endregion Constructor

        #region Public Member

        public string Name { get; set; }
        public ObservableCollection<PlayerInfoVM> PlayersColle { get; set; }

        #endregion Public Member
    }
}