using GalaSoft.MvvmLight;
using System;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel {

	public class MainViewModel : ViewModelBase {
		DispatcherTimer timer;
		private string time;

		public string Time {
			get { return time; }
			set { time = value; RaisePropertyChanged(); }
		}

		public MainViewModel() {
			Time = DateTime.Now.ToString("HH:mm:ss");
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Tick += TimerElapsed;
			timer.Start();
		}

		private void TimerElapsed(object sender, EventArgs e) {
			Time = DateTime.Now.ToString("HH:mm:ss");

		}
	}
}