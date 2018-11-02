using GalaSoft.MvvmLight;
using Shared.BaseModels;
using Shared.Interfaces;
using Simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel {

	public class MainViewModel : ViewModelBase {
		DispatcherTimer timer;
		private string time;

		public string Time {
			get { return time; }
			set { time = value; RaisePropertyChanged(); }
		}

		private List<ItemVm> itemsList = new List<ItemVm>();
		public ObservableCollection<ItemVm> Actuators { get; set; }
		public ObservableCollection<ItemVm> Sensors { get; set; }
		public ObservableCollection<string> ActuatorModeSelections { get; set; }
		public ObservableCollection<string> SensorModeSelections { get; set; }

		public MainViewModel() {
			Actuators = new ObservableCollection<ItemVm>();
			Sensors = new ObservableCollection<ItemVm>();
			ActuatorModeSelections = new ObservableCollection<string>();
			SensorModeSelections = new ObservableCollection<string>();

			SetupModeSelections();
			SetupTimer();
			SetupSimulator();
		}

		private void SetupModeSelections() {
			foreach (var item in Enum.GetNames(typeof(SensorModeType))) {
				SensorModeSelections.Add(item);
			}

			foreach (var item in Enum.GetNames(typeof(ModeType))) {
				ActuatorModeSelections.Add(item);
			}
		}

		private void SetupSimulator() {
			Simulator simulator = new Simulator(itemsList);

			simulator.Items.ForEach(item => {
				if (item.ItemType.Equals(typeof(ISensor))) {
					Sensors.Add(item);
				} else if (item.ItemType.Equals(typeof(IActuator))) {
					Actuators.Add(item);
				}
			});
		}

		// TIMER 
		private void SetupTimer() {
			Time = DateTime.Now.ToString("HH:mm");
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 10);
			timer.Tick += TimerElapsed;
			timer.Start();
		}
		private void TimerElapsed(object sender, EventArgs e) {
			Time = DateTime.Now.ToString("HH:mm");
		}
	}
}