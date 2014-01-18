using System;
using System.Windows;
using System.Windows.Controls;
using UI.Entities;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ProjectEntity project = new ProjectEntity(1);
            InitializeComponent();
            Switcher.window = this;
            this._mainContent.Children.Add(new UIElement());
        }

        private void BugControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void Navigate(UserControl page)
        {
            this._mainContent.Children.RemoveAt(0);
            this._mainContent.Children.Add(page);
            Grid.SetRow(page, 0);
        }

        public void Navigate(UserControl page, object state)
        {
            this._mainContent.Children[1] = page;
            Grid.SetRow(page, 1);

            ISwitchable s = page as ISwitchable;

            if (s == null)
            {
                throw new ArgumentException("page is not ISwitchable");
            }

            s.UtilizeState(state);
        }
    }
}
