using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject1;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            Boolean isLoggedIn = false;
            String password = "Test";
            if(isLoggedIn)
            {
                await Navigation.PushAsync(new HelloWorld());
            }
            else
            {
                if (password == passwordEditor.Text)
                {
                    DisplayAlert("Login Successful", "Login Successful!", "Continue");
                    await Navigation.PushAsync(new AppShell());
                }
                else
                {
                    DisplayAlert("Login Failed", "Login Failed. Please try again.", "Continue");
                }
            }
        }
    }
}