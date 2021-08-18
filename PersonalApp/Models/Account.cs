using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Models
{
  class Account
  {
    private string domain;
    private string username;
    private string password;

    public Account(string domain, string username, string password)
    {
      this.domain = domain;
      this.username = username;
      this.password = password;
    }

    public string Domain { get => domain; set => domain = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
  }
}
