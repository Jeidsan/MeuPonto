using MeuPonto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MeuPonto
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            
            MainPage = new MeuPonto.View.Consulta();
        }

        protected override void OnStart()
        {
            Database.CriarDatabase();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
