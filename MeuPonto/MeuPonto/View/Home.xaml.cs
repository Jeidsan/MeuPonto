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
    public partial class Home : ContentPage
    {       
        public Home()
        {
            InitializeComponent();
        }

        private void btnRegistrarPonto_Clicked(object sender, EventArgs e)
        {
            Ponto ponto = new Ponto() { Data = DateTime.Now };
            PontoDAO.GetInstance().Adicionar(ponto);
        }
    }
}
