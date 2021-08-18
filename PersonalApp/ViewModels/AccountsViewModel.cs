using PersonalApp.Models;
using PersonalApp.Services;
using System.Collections.ObjectModel;

namespace PersonalApp.ViewModels
{
	class AccountsViewModel : BaseViewModel
	{
		public ObservableCollection<Account> Accounts { get; set; }

		public AccountsViewModel()
		{
			Accounts = new ObservableCollection<Account>(DataService.GetAccounts());
		}
	}
}
