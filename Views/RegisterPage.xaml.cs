using _15830MAUI.Models;
using _15830MAUI.Services;

namespace _15830MAUI.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public RegisterPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) || 
                string.IsNullOrWhiteSpace(EmailEntry.Text) || 
                string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Llena todos los campos, por favor", "OK");
                return;
            }

            var user = new User
            {
                Name = NameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            var success = await _databaseService.RegisterUser(user);
            if (success)
            {
                await DisplayAlert("Success", "Registro exitoso", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Error", "Cuenta ya existente con ese correo", "OK");
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}