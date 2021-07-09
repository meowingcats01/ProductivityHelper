using MyProject1.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyProject1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QuickNoteEntry), typeof(QuickNoteEntry));
        }

        async void menuLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
