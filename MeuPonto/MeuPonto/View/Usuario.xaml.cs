using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.DAO;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        UsuarioDAO usuDao;
        EmpresaDAO empDAO;
        JornadaTrabalhoDAO jorDAO;
        bool novoCadastro;

        public Usuario(bool novoCadastroP)
        {
            InitializeComponent();
            this.novoCadastro = novoCadastroP;

        }

        protected void OnStart()
        {
            
            //botão Incluir
            btnIncluir.Click += delegate
            {
                Empresa emp = new Empresa()
                {
                    Nome = txtEmpresa.Text,
                    Cnpj = txtCnpj.Text
                };
                empDAO.InserirEmpresa(emp);

                JornadaTrabalho jor = new JornadaTrabalho()
                {
                    InicioTrabalho = txtIniTra.Text,
                    InicioAlmoco = txtIniAlm.Text,
                    TerminoAlmoco = txtFimAlm.Text,
                    TerminoTrabalho = txtFimTra.Text
                };
                jorDAO.InserirJornada(jor);

                Usuario usu = new Usuario()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    JornadaTrab = jor,
                    Empresa = emp
                };
                usuDao.InserirUsuario(usu);
            };

            //botão editar
            btnEditar.Click += delegate
            {
                Empresa emp = new Empresa()
                {
                    Nome = txtEmpresa.Text,
                    Cnpj = txtCnpj.Text
                };
                empDAO.AtualizarEmpresa(emp);

                JornadaTrabalho jor = new JornadaTrabalho()
                {
                    InicioTrabalho = txtIniTra.Text,
                    InicioAlmoco = txtIniAlm.Text,
                    TerminoAlmoco = txtFimAlm.Text,
                    TerminoTrabalho = txtFimTra.Text
                };
                jorDAO.AtualizarJornada(jor);

                Usuario usu = new Usuario()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    JornadaTrab = jor,
                    Empresa = emp
                };
                usuDao.AtualizarUsuario(usu);
            };

            //botão deletar
            btnDeletar.Click += delegate
            {
                Empresa emp = new Empresa()
                {
                    Nome = txtEmpresa.Text,
                    Cnpj = txtCnpj.Text
                };
                empDAO.DeletarEmpresa(emp);

                JornadaTrabalho jor = new JornadaTrabalho()
                {
                    InicioTrabalho = txtIniTra.Text,
                    InicioAlmoco = txtIniAlm.Text,
                    TerminoAlmoco = txtFimAlm.Text,
                    TerminoTrabalho = txtFimTra.Text
                };
                jorDAO.DeletarJornada(jor);

                Usuario usu = new Usuario()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    JornadaTrab = jor,
                    Empresa = emp
                };
                usuDao.DeletarUsuario(usu);
            };
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