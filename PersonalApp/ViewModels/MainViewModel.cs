using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using PersonalApp.Core.Utils;
using PersonalApp.UserControls;

namespace PersonalApp.ViewModels
{
	class MainViewModel : BaseViewModel
	{
		public ICommand Nav_Notes_Click { get; set; }
		public ICommand Nav_Accounts_Click { get; set; }
		public ICommand Nav_Users_Click { get; set; }
		public ICommand Nav_ReadDb_Click { get; set; }
		public ICommand Nav_Youtube_Click { get; set; }

		private UserControl _currentViewModel;

		public UserControl CurrentViewModel
		{
			get { return _currentViewModel; }
			set
			{
				_currentViewModel = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			Nav_Notes_Click = new CommandHandler(Show_Notes, CanExecute);
			Nav_Accounts_Click = new CommandHandler(Show_Accounts, CanExecute);
			Nav_Users_Click = new CommandHandler(Show_Users, CanExecute);
			Nav_ReadDb_Click = new CommandHandler(Show_ReadDs, CanExecute);
			Nav_Youtube_Click = new CommandHandler(Show_Youtube, CanExecute);

			CurrentViewModel = new EmptyUserControl();
		}

		public bool CanExecute()
		{
			return true;
		}
		public void Show_Notes()
		{
			CurrentViewModel = new NotesUserControl();
		}

		public void Show_Accounts()
		{
			CurrentViewModel = new AccountsUserControl();
		}

		public void Show_Users()
		{
			CurrentViewModel = new UsersUserControl();
		}

		public void Show_ReadDs()
		{
			MessageBox.Show("Show_ReadDs");
		}

		public void Show_Youtube()
		{
			CurrentViewModel = new YoutubeUserControl();
		}
	}
}
