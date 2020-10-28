using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowVM();
            Loaded += LoadedProc;
        }
        private async void LoadedProc(object sender, RoutedEventArgs e)
        {
            // WindowがActiveになるまで待つ
            await Task.Run(() =>
            {
                do
                {
                    Thread.Sleep(100);
                } while (!Application.Current.Dispatcher.Invoke(() => { return IsActive; }));
            });
            MainWindowVM vm = this.DataContext as MainWindowVM;
            vm.StartTimer();
        }
    }
}
