using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow用ViewModel
    /// </summary>
    class MainWindowVM : INotifyPropertyChanged
    {
        private int percentage = 0;

        public MainWindowVM()
        {
            t.Elapsed += T_Elapsed;
        }
        
        private Timer t = new Timer(1);
        public void StartTimer()
        {
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Percentage < 100)
            {
                Percentage += 1;

            }
            else
            {
                Percentage = 0;
            }
        }


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
