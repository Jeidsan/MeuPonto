using MeuPonto.DAO;
using MeuPonto.Model;
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
    public partial class MainPage : ContentPage
    {
        PontoDAO pontoDAO = PontoDAO.GetInstance();

        public MainPage()
        {
            InitializeComponent();

            //Ponto ponto = pontoDAO.ConsultarPontoDia();
            //txtHoraInicioTrabalho.Time = ponto.InicioTrabalho;
            //txtHoraInicioAlmoco.Time = ponto.InicioAlmoco;
            //txtHoraFimAlmoco.Time = ponto.TerminoAlmoco;
            //txtHoraFimTrabalho.Time = ponto.TerminoTrabalho;
        }

        private void btnRegistrarPonto_Clicked(object sender, EventArgs e)
        {
            Ponto ponto = new Ponto()
            {
                Data = DateTime.Now
            };
            pontoDAO.Adicionar(ponto);
        }
    }
}
