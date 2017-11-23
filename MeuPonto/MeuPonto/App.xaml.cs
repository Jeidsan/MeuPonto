using MeuPonto.Base;
using Xamarin.Forms;

namespace MeuPonto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database.CriarDatabase();
            MainPage = new MeuPonto.View.Consulta();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
