using MyProject1.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class QuickNoteEntry : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public QuickNoteEntry()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        void LoadNote(string filename)
        {
            try
            {
                Note note = new Note
                {
                    fileName = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                };
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void btnSave_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.fileName))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.fileName, note.Text);
            }

            await Shell.Current.GoToAsync("..");
        }

        async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.fileName))
            {
                File.Delete(note.fileName);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}