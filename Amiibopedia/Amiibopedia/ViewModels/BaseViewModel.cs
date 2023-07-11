using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Amiibopedia.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private bool isBusy;

		public bool IsBusy
		{
			get => isBusy;
			set
			{
				isBusy = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
		}
	}
}
