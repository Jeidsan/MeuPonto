using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.DAO;
using MeuPonto.Model;

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

        public Usuario(bool novoCadastroP, Model.Usuario usuarioLogadoP)
        {
            InitializeComponent();
            this.novoCadastro = novoCadastroP;
            this.usuarioLogado = usuarioLogadoP;
            txtNome.Text = "Luiz";
            txtEmail.Text = "meuemail";
            txtCPF.Text = "9999";
            txtTelefone.Text = "8888";
            txtLogin.Text = "login";
            txtSenha.Text = "senha";
            txtEmpresa.Text = "empresa";
            txtCnpj.Text = "7777";
            txtHoraInicioTrabalho.Time = new TimeSpan();
            txtHoraInicioAlmoco.Time = new TimeSpan();
            txtHoraFimAlmoco.Time = new TimeSpan();
            txtHoraFimTrabalho.Time = new TimeSpan();

        }

        private void btnCadastrarLocalizacaoClicked()
        {

        }

        private void btnSalvarClicked()
        {
            if (novoCadastro == true)
                {InserirUsuario();}
            else
                {AtualizarUsuario();}

            IEnumerable<Model.Usuario> usuarios = usuDao.Consultar();
            var message = "";
            foreach (Model.Usuario usu in usuarios)
            {
                message = string.Concat("Nome: ", usu.Nome, "\n");
                message = string.Concat(message, "CPF: ", usu.Cpf, "\n");
                message = string.Concat(message, "Email: ", usu.Email, "\n");
                message = string.Concat(message, "Telefone: ", usu.Telefone, "\n");
                message = string.Concat(message, "Login: ", usu.Login, "\n");
                message = string.Concat(message, "Senha: ", usu.Senha, "\n");
                message = string.Concat(message, "Empresa Id: ", usu.Empresa.Id, "\n");              
 //               message = string.Concat(message, "Empresa: ", usu.Empresa.Nome, "\n");
  //              message = string.Concat(message, "Empresa Id: ", usu.Empresa.Id, "\n");
                //               message = string.Concat(message, "CNPJ: ", usu.Empresa.Cnpj, "\n");
                message = string.Concat(message, "JornadaTrabId: ", usu.JornadaTrab.Id, "\n");
 //               message = string.Concat(message, "InicioTrabalho: ", usu.JornadaTrab.InicioTrabalho, "\n");
 //               message = string.Concat(message, "InicioAlmoco: ", usu.JornadaTrab.InicioAlmoco, "\n");
  //              message = string.Concat(message, "TerminoAlmoco: ", usu.JornadaTrab.TerminoAlmoco, "\n");
  //              message = string.Concat(message, "TerminoTrabalho: ", usu.JornadaTrab.TerminoTrabalho, "\n");
                DisplayAlert(string.Concat("Usuário: ", usu.Id), message, "OK");
            }           

        }
        
        private void btnCancelarClicked()
        {

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
                Senha = txtSenha.Text
            };
            usuDao.Adicionar(usu);

            Empresa emp = new Empresa()
            {
                EmpresaId = usu.Id,
                Nome = txtEmpresa.Text,
                Cnpj = txtCnpj.Text
            };
            empDAO.Adicionar(emp);

            JornadaTrabalho jor = new JornadaTrabalho()
            {
                JornadaTrabId = usu.Id,
                InicioTrabalho = txtHoraInicioTrabalho.Time,
                InicioAlmoco = txtHoraInicioAlmoco.Time,
                TerminoAlmoco = txtHoraFimAlmoco.Time,
                TerminoTrabalho = txtHoraFimTrabalho.Time
            };
            jorDAO.Adicionar(jor);
                      
            usu.JornadaTrab = jor;
            usu.Empresa = emp;
            jorDAO.Atualizar(jor);
            empDAO.Atualizar(emp);
            usuDao.Atualizar(usu);

            
        }

        private void AtualizarUsuario()
        {
            Empresa emp = new Empresa()
            {
                Nome = txtEmpresa.Text,
                Cnpj = txtCnpj.Text
            };
            empDAO.Atualizar(emp);

            JornadaTrabalho jor = new JornadaTrabalho()
            {
                InicioTrabalho = txtHoraInicioTrabalho.Time,
                InicioAlmoco = txtHoraInicioAlmoco.Time,
                TerminoAlmoco = txtHoraFimAlmoco.Time,
                TerminoTrabalho = txtHoraFimTrabalho.Time
            };
            jorDAO.Atualizar(jor);

            Model.Usuario usu = new Model.Usuario()
            {
                Id = usuarioLogado.Id,
                Nome = txtNome.Text,
                Cpf = txtCPF.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Login = txtLogin.Text,
                Senha = txtSenha.Text,
                JornadaTrab = jor,
                Empresa = emp
            };
            usuDao.Atualizar(usu);
        }
    }
}