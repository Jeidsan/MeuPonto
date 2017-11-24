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
        public Usuario()
        {
            InitializeComponent();
            if (Sistema.UsuarioLogado != null)
            {
                PreencherCampos();
            }
            lblTitulo.IsVisible = Sistema.UsuarioLogado == null;
        }

        private void PreencherCampos()
        {
            txtNome.Text = Sistema.UsuarioLogado.Nome;
            txtLogin.Text = Sistema.UsuarioLogado.Login;
            txtSenha.Text = "********";
            txtCPF.Text = String.Format("{0:###.###.###-##}", Sistema.UsuarioLogado.Cpf);
            txtTelefone.Text = Sistema.UsuarioLogado.Telefone;
            txtEmail.Text = Sistema.UsuarioLogado.Email;
            txtEmpresa.Text = Sistema.UsuarioLogado.Empresa;
            txtCnpj.Text = Sistema.UsuarioLogado.Cnpj;
            //TODO: Jeidsan: Preencher os campos TimePiker
            txtLatitude.Text = Sistema.UsuarioLogado.Latitude.ToString("###0.00");
            txtLongitude.Text = Sistema.UsuarioLogado.Longitude.ToString("###0.00");
        }

        private void btnSalvarClicked()
        {
            if (Sistema.UsuarioLogado == null)
            {
                InserirUsuario();
                App.Current.MainPage = new View.Login();
            }
            else
            {
                AtualizarUsuario();
                App.Current.MainPage = new View.Home();
            }
        }

        private void btnCancelarClicked()
        {
            if (Sistema.UsuarioLogado == null)
            {
                App.Current.MainPage = new View.Login();
            }
            else
            {
                App.Current.MainPage = new View.Home();
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
                Latitude = Convert.ToDouble(String.IsNullOrWhiteSpace(txtLatitude.Text) ? "0" : txtLatitude.Text),
                Longitude = Convert.ToDouble(String.IsNullOrWhiteSpace(txtLongitude.Text) ? "0" : txtLongitude.Text)
            };
            UsuarioDAO.GetInstance().Adicionar(usu);
        }

        private async void btnCadastrarLocalizacao_Clicked(object sender, EventArgs e)
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync();
                txtLatitude.Text = position.Latitude.ToString("##0.00");
                txtLongitude.Text = position.Longitude.ToString("##0.00");
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
                Latitude = Convert.ToDouble(txtLatitude.Text),
                Longitude = Convert.ToDouble(txtLongitude.Text)
            };
            UsuarioDAO.GetInstance().Atualizar(usu);
        }
    }
}