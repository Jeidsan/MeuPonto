using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.Controller;
using MeuPonto.DAO;
using MeuPonto.Model;
using Plugin.Geolocator;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {        
        public Login()
        {
            InitializeComponent();
            
        }
        
        private void btnLogin_Clicked(object sender, EventArgs e)
        {           
            UsuarioController usuarioController = new UsuarioController();
            Sistema.UsuarioLogado = usuarioController.Autenticar(txtLogin.Text, txtSenha.Text);

            if (Sistema.UsuarioLogado != null)
            {
                App.Current.MainPage = new View.MainPage();
            }
            else
            {
                DisplayAlert("Alerta ", "Usuário ou senha incorreta!", "OK");
            }
           
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new View.Usuario(true);
        }
    }
}