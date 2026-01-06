using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TpvlDataAnalyzer.View;
using TpvlDataAnalyzer.ViewModel;

namespace TpvlDataAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Member

        private MainVM _vm;

        #endregion Private Member

        public MainWindow()
        {
            InitializeComponent();

            _vm = new MainVM();
            _vm.CommandAction += On_MainVM_CommandAction;

            this.DataContext = _vm;
        }

        private void On_MainVM_CommandAction(object? sender, string cmdKey)
        {
            if (cmdKey == nameof(_vm.CmdShowPlayerFilterDialog))
            {
                PlayerFilterDialogVM dialogVM = new PlayerFilterDialogVM(_vm.PlayersList);
                PlayerFilterDialog dialog = new PlayerFilterDialog();
                dialog.Owner = this;
                dialog.DataContext = dialogVM;
                bool? result = dialog.ShowDialog();
                _vm.UpdateCollectionByFilter();
            }
        }
    }
}