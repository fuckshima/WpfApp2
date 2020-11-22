using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow用ViewModel
    /// </summary>
    class MainWindowVM : INotifyPropertyChanged
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowVM()
        {
            // 
            progressTimer.Elapsed += T_Elapsed;
            func = new DelegateCommand(execute: StartTimer);
        }
        
        // プログレスバー専用タイマー
        private readonly Timer progressTimer = new Timer(1);

        public ICommand func { get; set; } = null;

        /// <summary>
        /// タイマー開始
        /// </summary>
        public void StartTimer()
        {
            progressTimer.Start();
        }

        /// <summary>
        /// Timer発火時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 100以上の時、0から再スタート
            if (Percentage < 100)
            {
                Percentage += 1;

            }
            else
            {
                Percentage = 0;
            }
        }

        // 進捗率
        private int percentage = 0;
        public int Percentage
        {
            get
            {
                return this.percentage;
            }
            set
            {
                this.percentage = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
