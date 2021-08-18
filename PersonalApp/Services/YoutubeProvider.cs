using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VideoLibrary;

namespace PersonalApp.Services
{
	public static class YoutubeProvider
  {
    private static string selectedPath;

    public static string SELECTED_PATH
    {
      get
      {
        if (selectedPath == null)
          selectedPath = GetDefaultFolder();

        return selectedPath;
      }
      set
      {
        selectedPath = value;
      }
    }

    public async static Task DownloadVideoAsync(string url)
    {      
      var service = Client.For(YouTube.Default);

      var video = await service.GetVideoAsync(url);     

      string path = Path.Combine(SELECTED_PATH, video.FullName);

      byte[] videData = await video.GetBytesAsync();

      File.WriteAllBytes(path, videData);      
    }

    public static string SelectPath()
    {
      CommonOpenFileDialog dialog = new CommonOpenFileDialog();
        
      dialog.IsFolderPicker = true;

      if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
      {
        MessageBox.Show("You selected: " + dialog.FileName);
      }

      SELECTED_PATH = dialog.FileName;

      return dialog.FileName;
    }

    public static string GetDefaultFolder()
    {
      string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

      return Path.Combine(home, "Downloads");
    }
  }
}
