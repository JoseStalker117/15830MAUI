using _15830MAUI.Services;

namespace _15830MAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public LoginPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Llena todos los campos, por favor", "OK");
                return;
            }

            var user = await _databaseService.LoginUser(EmailEntry.Text, PasswordEntry.Text);
            if (user != null)
            {
                var profilePage = new ProfilePage(user.Name, user.Email);
                await Navigation.PushAsync(profilePage);
            }
            else
            {
                await DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
} 