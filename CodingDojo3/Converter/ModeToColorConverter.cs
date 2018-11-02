using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CodingDojo3.Converter {
	[ValueConversion(typeof(string), typeof(Color))]
	public class ModeToColorConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

			if ((value as string).Equals("Enabled")) {
				return new SolidColorBrush(Colors.Green);
			} else {
				return new SolidColorBrush(Colors.Red);
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
