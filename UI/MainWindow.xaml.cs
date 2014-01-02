using System.Windows;
using NLog;
using UI.Entities;
namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Logger log;
        public MainWindow()
        {
            ProjectEntity project = new ProjectEntity(1);
            InitializeComponent();
        }

        private void BugControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
