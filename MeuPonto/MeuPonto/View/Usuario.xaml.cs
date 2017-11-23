using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.DAO;
using MeuPonto.Model;
using Plugin.Geolocator;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        UsuarioDAO usuDao = UsuarioDAO.GetInstance();
        bool novoCadastro;
        double latitudeLocalTrab, longitudeLocalTrab = 0;

        public Usuario(bool novoCadastroP)
        {
            InitializeComponent();
            this.novoCadastro = novoCadastroP;
        }

        private void btnSalvarClicked()
        {
            if (novoCadastro == true)
            {
                InserirUsuario();
                App.Current.MainPage = new View.Login();
            }
            else
            {
                AtualizarUsuario();
                App.Current.MainPage = new View.MainPage();
            }
        }
        
        private void btnCancelarClicked()
        {            
            if (novoCadastro == true)
            {
                App.Current.MainPage = new View.Login();
            }
            else
            {
                App.Current.MainPage = new View.MainPage();
            }
        }

        private void InserirUsuario()
        {
            Model.Usuario usu = new Model.Usuario()
            {
                Nome = txtNome.Text,
                Cpf = txtCPF.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Login = txtLogin.Text,
                Senha = txtSenha.Text,
                Empresa = txtEmpresa.Text,
                Cnpj = txtCnpj.Text,
                InicioTrabalho = txtHoraInicioTrabalho.Time,
                InicioAlmoco = txtHoraInicioAlmoco.Time,
                TerminoAlmoco = txtHoraFimAlmoco.Time,
                TerminoTrabalho = txtHoraFimTrabalho.Time,
                Latitude = latitudeLocalTrab,
                Longitude = longitudeLocalTrab
            };
            usuDao.Adicionar(usu);
        }

        private async void btnCadastrarLocalizacao_Clicked(object sender, EventArgs e)
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync();
                latitudeLocalTrab = position.Latitude;
                longitudeLocalTrab = position.Longitude;
                AtualizarUsuario();
                await DisplayAlert("Meu Ponto", "Localização registrada com sucesso", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Meu Ponto", "Ocorreu um erro ao buscar a sua localização. Por favor, tente novamente.", "OK");
            }
        }

        private void AtualizarUsuario()
        {

            Model.Usuario usu = new Model.Usuario()
            {
                Id = Sistema.UsuarioLogado.Id,
                Nome = txtNome.Text,
                Cpf = txtCPF.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Login = txtLogin.Text,
                Senha = txtSenha.Text,
                Empresa = txtEmpresa.Text,
                Cnpj = txtCnpj.Text,
                InicioTrabalho = txtHoraInicioTrabalho.Time,
                InicioAlmoco = txtHoraInicioAlmoco.Time,
                TerminoAlmoco = txtHoraFimAlmoco.Time,
                TerminoTrabalho = txtHoraFimTrabalho.Time,
                Latitude = latitudeLocalTrab,
                Longitude = longitudeLocalTrab
            };
            usuDao.Atualizar(usu);
        }
    }
}