using Xamarin.Forms;

namespace Demo2FA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.SignUpView();
        }
    }
}
