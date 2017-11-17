using MeuPonto.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        private UsuarioController fController;
        private UsuarioController Controller
        {
            get
            {
                if (fController == null)
                    fController = new UsuarioController();
                return fController;
            }
        }

        public Usuario()
        {
            InitializeComponent();           
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                DateTime inicioJornada = new DateTime(2000, 1, 1, txtHoraInicioAlmoco.Time.Hours, txtHoraInicioAlmoco.Time.Minutes, 0);
                DateTime inicioAlmoco = new DateTime(2000, 1, 1, txtHoraInicioAlmoco.Time.Hours, txtHoraInicioAlmoco.Time.Minutes, 0);
                DateTime fimAlmoco = new DateTime(2000, 1, 1, txtHoraInicioAlmoco.Time.Hours, txtHoraInicioAlmoco.Time.Minutes, 0);
                DateTime fimJornada = new DateTime(2000, 1, 1, txtHoraInicioAlmoco.Time.Hours, txtHoraInicioAlmoco.Time.Minutes, 0);

                Controller.Cadastrar(txtNome.Text, txtLogin.Text, txtSenha.Text, txtCPF.Text, txtTelefone.Text, txtEmail.Text, inicioJornada, inicioAlmoco, fimAlmoco, fimJornada);

                DisplayAlert("Meu Ponto", "Usuário cadastrado com sucesso", "Ok");
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Fechar");
            }
        }
    }
}