using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.Model;
using MeuPonto.DAO;

using MeuPonto.Base;
using SQLite.Net;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {

        // Criar botão para voltar

        public Consulta()
        {

            IEnumerable<Ponto> listaPontos = PontoDAO.GetInstance().Consultar();
            string[] mensagem = new string[listaPontos.Count()];
            int count = 0;
            foreach (Ponto ponto in listaPontos)
                {mensagem[count] = ponto.Data.ToString();count++;}
            

            //List<ConsultaPonto> listaPontosDias = PontoDAO.GetInstance().RealizarConsulta();
            //string[] mensagem = new string[listaPontosDias.Count()];
            //int count = 0;
            //foreach (ConsultaPonto pontosDia in listaPontosDias)
            //    {mensagem[count] = pontosDia.Linha.ToString(); count++;}

            InitializeComponent();

            this.ListaPontos.ItemsSource = mensagem;
            lblHorasTrabalhadas.Text = "170";
            lblSaldoHoras.Text = "10";

        }       
    }

}