using PersonalApp.Core.Utils;
using PersonalApp.Models;
using PersonalApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalApp.ViewModels
{
	class YoutubeViewModel : BaseViewModel
	{
		private string url = "";

		private string folder = YoutubeProvider.SELECTED_PATH;
		public ICommand DownloadClick { get; set; }
		public ICommand SelectPathClick { get; set; }
		public ObservableCollection<DownloadingItem> Downloaded { get; set; }
		public string Url
		{
			get => this.url;
			set
			{
				if (!string.Equals(this.url, value))
				{
					this.url = value;
					this.OnPropertyChanged();
				}
			}
		}

		public string Folder
		{
			get => this.folder;
		}

		public YoutubeViewModel()
		{
			DownloadClick = new CommandHandler(() => Download(), CanDownload);
			SelectPathClick = new CommandHandler(() => SelectPath(), CanChangePath);

			Downloaded = new ObservableCollection<DownloadingItem>();

			this.PropertyChanged += URL_PropertyChanged;
		}

		private void URL_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			DownloadClick.CanExecute(CanDownload());
		}

		private void SelectPath()
		{
			YoutubeProvider.SelectPath();
		}

		private async void Download()
		{
			DownloadingItem item = new DownloadingItem("null", 0);

			Downloaded.Add(item);

			Task downloaderTask = new Task(async () =>
			{
				await YoutubeProvider.DownloadVideoAsync(Url);
				item.Percentage = 100;
			});

			await Task.Run(async () => await downloaderTask);
		}

		private bool CanDownload()
		{
			return Url.Contains(@"https://www.youtube.com/watch?v=");
		}

		private bool CanChangePath()
		{
			return true;
		}
	}
}
