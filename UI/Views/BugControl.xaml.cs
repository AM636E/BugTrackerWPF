using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Messaging;

using UI.Helpers;
using UI.ViewModel;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for BugControl.xaml
    /// </summary>
    public partial class BugControl : UserControl
    {
        public BugControl()
        {
            InitializeComponent();

            Messenger.Default.Send(new ViewCollectionViewSourceMessageToken() { CVS = (CollectionViewSource)(this.Resources["Bugs"]) });
        }
    }
}
