using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonalApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(field, newValue))
			{
				field = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
