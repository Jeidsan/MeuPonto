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
        }
        
        private void btnCancelarClicked()
        {

        }

        private void btnCadastrarIrisClicked()
        {

        }

        private void InserirUsuario()
        {
            Empresa emp = new Empresa()
            {
                Nome = txtEmpresa.Text,
                Cnpj = txtCnpj.Text
            };
            empDAO.Adicionar(emp);

            JornadaTrabalho jor = new JornadaTrabalho()
            {
                InicioTrabalho = txtHoraInicioTrabalho.Time,
                InicioAlmoco = txtHoraInicioAlmoco.Time,
                TerminoAlmoco = txtHoraFimAlmoco.Time,
                TerminoTrabalho = txtHoraFimTrabalho.Time
            };
            jorDAO.Adicionar(jor);

           Model.Usuario usu = new Model.Usuario()
            {
                Nome = txtNome.Text,
                Cpf = txtCPF.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Login = txtLogin.Text,
                Senha = txtSenha.Text,
                JornadaTrab = jor,
                Empresa = emp
            };            
            usuDao.Adicionar(usu);
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