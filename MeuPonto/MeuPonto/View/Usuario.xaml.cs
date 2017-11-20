using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        EmpresaDAO empDAO = EmpresaDAO.GetInstance();
        JornadaTrabalhoDAO jorDAO = JornadaTrabalhoDAO.GetInstance();
        Model.Usuario usuarioLogado;
        bool novoCadastro;
        double latitudeLocalTrab, longitudeLocalTrab = 0;

        public Usuario(bool novoCadastroP, Model.Usuario usuarioLogadoP)
        {
            InitializeComponent();
            this.novoCadastro = novoCadastroP;
            this.usuarioLogado = usuarioLogadoP;

            //txtNome.Text = "Luiz";
            //txtEmail.Text = "meuemail";
            //txtCPF.Text = "9999";
            //txtTelefone.Text = "8888";
            //txtLogin.Text = "login";
            //txtSenha.Text = "senha";
            //txtEmpresa.Text = "empresa";
            //txtCnpj.Text = "7777";
            //txtHoraInicioTrabalho.Time = new TimeSpan();
            //txtHoraInicioAlmoco.Time = new TimeSpan();
            //txtHoraFimAlmoco.Time = new TimeSpan();
            //txtHoraFimTrabalho.Time = new TimeSpan();
        }

        private async void btnCadastrarLocalizacaoClicked(object sender, EventArgs e)
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync();                
                latitudeLocalTrab = position.Latitude;
                longitudeLocalTrab = position.Longitude;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "OK");
            }
        }

        private void btnSalvarClicked()
        {
            if (novoCadastro == true)
                {InserirUsuario();}
            else
                {AtualizarUsuario();}

            //IEnumerable<Model.Usuario> usuarios = usuDao.Consultar();
            //var message = "";
            //foreach (Model.Usuario usu in usuarios)
            //{
            //    message = string.Concat("Nome: ", usu.Nome, "\n");
            //    message = string.Concat(message, "CPF: ", usu.Cpf, "\n");
            //    message = string.Concat(message, "Email: ", usu.Email, "\n");
            //    message = string.Concat(message, "Telefone: ", usu.Telefone, "\n");
            //    message = string.Concat(message, "Login: ", usu.Login, "\n");
            //    message = string.Concat(message, "Senha: ", usu.Senha, "\n");         
            //    message = string.Concat(message, "Empresa: ", usu.Empresa, "\n");
            //    message = string.Concat(message, "CNPJ: ", usu.Cnpj, "\n");
            //    message = string.Concat(message, "InicioTrabalho: ", usu.InicioTrabalho, "\n");
            //    message = string.Concat(message, "InicioAlmoco: ", usu.InicioAlmoco, "\n");
            //    message = string.Concat(message, "TerminoAlmoco: ", usu.TerminoAlmoco, "\n");
            //    message = string.Concat(message, "TerminoTrabalho: ", usu.TerminoTrabalho, "\n");
            //    message = string.Concat(message, "Latitude: ", usu.Latitude, "\n");
            //    message = string.Concat(message, "Longitude: ", usu.Longitude, "\n");

            //    DisplayAlert(string.Concat("Usuário: ", usu.Id), message, "OK");
            //}           

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

        private void btnCadastrarIrisClicked()
        {

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

        private void AtualizarUsuario()
        {

            Model.Usuario usu = new Model.Usuario()
            {
                Id = usuarioLogado.Id,
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