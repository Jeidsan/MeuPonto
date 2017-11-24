using MeuPonto.Base;
using MeuPonto.Model;
using Xamarin.Forms;

namespace MeuPonto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            if (Sistema.UsuarioLogado == null)
            {
                MainPage = new View.Login();
            }
            else
            {
                MainPage = new View.Main();
            }
        }

        protected override void OnStart()
        {
            if (Database.GetConnection() != null)
            {
                Database.CriarDatabase();
            }
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
