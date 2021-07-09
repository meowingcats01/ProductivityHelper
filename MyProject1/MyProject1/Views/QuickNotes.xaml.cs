using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject1.Models;
using System.IO;
using Xamarin.Forms;

namespace MyProject1.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

           var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    fileName = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            noteCollection.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void addNoteItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(QuickNoteEntry));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(QuickNoteEntry)}?{nameof(QuickNoteEntry.ItemId)}={note.fileName}");
            }
        }
    }
}