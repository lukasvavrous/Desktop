using PersonalApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Services
{
	class DataService
	{
		private static protected string _password = "tatarka";

		private static List<Account> Accounts = new List<Account>()
		{
			new Account("www.facebook.com", "gwawgwag", "GsIQfM+fOYvG+A/W4tuNihrWRhMcZvJv1Byti6qewNhFAH/jQlEZJtCYAd09njeMhrwNuZHyI9jP5dsCuegolrx6UXEuwd/rZh43kA/T225+IdioLbjZU41N9Ps6l7Co")
		};

		private static List<Note> Notes = new List<Note>()
		{
			new Note("Rozjebat kompa", "Nevím co k tomu ještě dodat, prostě ho rozjebat", 10),
			new Note("Nasrat lukáše", "Jedeme dom?", 5),
			new Note("Dodělat povinnosti", "Na to sere pes", 0)
		};

		public static ICollection<Account> GetAccounts()
		{
			return Accounts.Select(x => new Account(x.Domain, x.Username, Decrypt(x.Password))).ToList();
		}

		public static ICollection<Note> GetNotes()
		{
			return Notes;
		}

		private static string Encrypt(string str)
		{
			string encrypted = StringCryption.Encrypt(str, _password);

			Trace.WriteLine(encrypted);

			return encrypted;
		}

		private static string Decrypt(string str)
		{
			string encrypted = StringCryption.Decrypt(str, _password);

			Trace.WriteLine(encrypted);

			return encrypted;
		}
	}
}
