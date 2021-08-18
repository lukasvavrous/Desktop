using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Models
{
  public class DownloadingItem
  {
    public string Title { get; set; }
    public int Percentage { get; set; }

    public DownloadingItem(string title, int percentage)
    {
      Title = title;
      Percentage = percentage;
    }
  }
}
