using MeuPonto.DAO;
using MeuPonto.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {       
        public Home()
        {
            InitializeComponent();
        }

        private void btnRegistrarPonto_Clicked(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            //Ponto ponto = new Ponto() { Data = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy HH:mm:ss", culture)};
            //Ponto ponto = new Ponto() { Data = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", culture)) };

            //Ponto ponto = new Ponto() { Data = DateTime.ParseExact(DateTime.Now.ToString(), "dd-MM-yyyy hh:mm:ss:tt", culture) };
            Ponto ponto = new Ponto() { Data = DateTime.Now };

            PontoDAO.GetInstance().Adicionar(ponto);
        }
    }
}
