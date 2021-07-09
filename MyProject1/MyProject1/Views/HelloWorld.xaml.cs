using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelloWorld : ContentPage
    {
        public HelloWorld()
        {
            InitializeComponent();
        }

        private void btnOK_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hi!", "Hello and welcome to my application, " + entryName.Text + "!", "OK!");
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            entryName.Text = "";
        }
    }
}