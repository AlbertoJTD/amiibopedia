using Amiibopedia.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Amiibopedia
{
	public partial class MainPage : ContentPage
	{
        public MainPageViewModel ViewModel { get; set; }

		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			ViewModel = new MainPageViewModel();
			this.BindingContext = ViewModel;
			await ViewModel.LoadCharacters();
		}
	}
}
