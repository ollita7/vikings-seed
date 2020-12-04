
using Seed.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Test", "Accediendo","OK");
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            DisplayAlert("Test", "Registrarse", "OK");
        }
    }
}