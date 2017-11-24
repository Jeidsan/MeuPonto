using MeuPonto.DAO;
using MeuPonto.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            Sistema.UsuarioLogado = UsuarioDAO.GetInstance().Autenticar(txtLogin.Text, txtSenha.Text);

            if (Sistema.UsuarioLogado == null)
            {
                DisplayAlert("Alerta ", "Usuário ou senha incorreta!", "OK");
            }
            else
            {
                App.Current.MainPage = new View.Main();
            }
           
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new View.Usuario();
        }
    }
}