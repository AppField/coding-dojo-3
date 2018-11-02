using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;

namespace CodingDojo3.ViewModel {
	public class ItemVm : ViewModelBase {

		private ItemBase item;

		public int Id { get { return item.Id; } }

		public string Description {
			get { return item.Description; }
			set { item.Description = value; RaisePropertyChanged(); }
		}
		public string Name {
			get { return item.Name; }
			set { item.Name = value; RaisePropertyChanged(); }
		}

		public string Room {
			get { return item.Room; }
			set { item.Room = value; RaisePropertyChanged(); }
		}

		public int PosX {
			get { return item.PosX; }
			set { item.PosX = value; RaisePropertyChanged(); }
		}

		public int PosY {
			get { return item.PosY; }
			set { item.PosY = value; RaisePropertyChanged(); }
		}

		public string ValueType {
			get {
				if (item is ISensor) {
					return (item as BaseSensor).SensorValueType.Name;
				} else if (item is IActuator) {
					return (item as BaseActuator).ActuatorValueType.Name;
				} else {
					throw new NotImplementedException();
				}
			}
		}

		public Type ItemType {
			get {

				if (item is ISensor) return typeof(ISensor);
				else if (item is IActuator) return typeof(IActuator);
				else throw new NotImplementedException();
			}
		}

		public string Mode {
			get {
				if (item is ISensor) return (item as ISensor).SensorMode.ToString();
				if (item is IActuator) return (item as IActuator).ActuatorMode.ToString();
				return null;
			}
			set {
				if (item is ISensor) {
					(item as BaseSensor).SensorMode = (SensorModeType)Enum.Parse(typeof(SensorModeType), value, false);
				}
				if (item is IActuator) {
					(item as BaseActuator).ActuatorMode = (ModeType)Enum.Parse(typeof(ModeType), value, false);
				}

				RaisePropertyChanged();
			}
		}

		public object Value {
			get {
				if (item is ISensor) return (item as BaseSensor).SensorValue;
				else if (item is IActuator) return (item as BaseActuator).ActuatorValue;
				else throw new NotImplementedException();
			}
			set {
				if (item is ISensor) (item as BaseSensor).SensorValue = value;
				else if (item is IActuator) (item as BaseActuator).ActuatorValue = value;
				else throw new NotImplementedException();

				RaisePropertyChanged();
			}
		}

		//public ItemVm(ItemBase sensor) {
		//	item = sensor;
		//}

		public ItemVm(ISensor sensor) {
			item = sensor as ItemBase;
		}

		public ItemVm(IActuator actuator) {
			item = actuator as ItemBase;
		}

	}
}
