using Amiibopedia.Helpers;
using Amiibopedia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Amiibopedia.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos { get; set; }
        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
			SearchCommand = new Command(async (text) =>
			{
				string url = $"https://www.amiiboapi.com/api/amiibo/?character={text}";
				var service = new HttpHelper<Amiibos>();
				var amiibos = await service.GetRestServiceDataAsync(url);
				Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
			});
        }

        public async Task LoadCharacters()
		{
			var url = "https://www.amiiboapi.com/api/character/";
			var service = new HttpHelper<Characters>();
			var characters = await service.GetRestServiceDataAsync(url);
			Characters = new ObservableCollection<Character>(characters.amiibo);
		}
    }
}
