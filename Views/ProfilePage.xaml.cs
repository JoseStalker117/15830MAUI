using Microsoft.Maui.Controls;

namespace _15830MAUI.Views
{
    public partial class ProfilePage : ContentPage
    {
        private string _name;
        private string _email;

        public ProfilePage()
        {
            InitializeComponent();
        }

        public ProfilePage(string name, string email)
        {
            InitializeComponent();
            _name = name;
            _email = email;
            UpdateUI();
        }

        private void UpdateUI()
        {
            NameLabel.Text = $"Nombre: {_name}";
            EmailLabel.Text = $"Correo: {_email}";
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
} 