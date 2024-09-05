using CalendarForTeacherPrikhodkoAP42IS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarForTeacherPrikhodkoAP42IS.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private System.Timers.Timer _timer;
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public int DaysUntilSummer => DaysCalculator.DaysUntilSummer(SelectedDate);
        public int HoursUntilSummer => DaysCalculator.HoursUntilSummer(SelectedDate);
        public int MinutesUntilSummer => DaysCalculator.MinutesUntilSummer(SelectedDate);
        public int SecondsUntilSummer => DaysCalculator.SecondsUntilSummer(SelectedDate);

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarViewModel()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += (sender, args) =>
            {
                SelectedDate = DateTime.Now;
                OnPropertyChanged(nameof(DaysUntilSummer));
                OnPropertyChanged(nameof(HoursUntilSummer));
                OnPropertyChanged(nameof(MinutesUntilSummer));
                OnPropertyChanged(nameof(SecondsUntilSummer));
            };
            _timer.Start();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
