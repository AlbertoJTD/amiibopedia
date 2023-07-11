using Amiibopedia.Helpers;
using Amiibopedia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Amiibopedia.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
        public ObservableCollection<Character> Characters { get; set; }

		public async Task LoadCharacters()
		{
			var url = "https://www.amiiboapi.com/api/character/";
			var service = new HttpHelper<Characters>();
			var characters = await service.GetRestServiceDataAsync(url);
			Characters = new ObservableCollection<Character>(characters.amiibo);
		}
    }
}
