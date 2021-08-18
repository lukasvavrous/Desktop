using PersonalApp.Models;
using PersonalApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace PersonalApp.ViewModels
{
  class NotesViewModel : BaseViewModel
  {
    public ObservableCollection<Note> Notes { get; set; }

    private Note _selectedNote;

    public Note SelectedNote
    {
      get => _selectedNote;
      set
      {
        _selectedNote = value;
        OnPropertyChanged();
      }
    }

    public NotesViewModel()
    {
      Notes = new ObservableCollection<Note>(DataService.GetNotes());

      PropertyChanged += NotesViewModel_PropertyChanged;
    }

    private void NotesViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      MessageBox.Show(SelectedNote.Content);
    }
  }
}
