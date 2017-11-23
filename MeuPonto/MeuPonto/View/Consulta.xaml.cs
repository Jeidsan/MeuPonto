using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.Model;
using MeuPonto.DAO;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        public Consulta()
        {
            //Ponto[] listaPontos = new Ponto[5];
            //listaPontos[0] = new Ponto(DateTime.Today);
            //listaPontos[1] = new Ponto(DateTime.Today);
            //listaPontos[2] = new Ponto(DateTime.Today);
            //listaPontos[3] = new Ponto(DateTime.Today);
            //listaPontos[4] = new Ponto(DateTime.Today);

            IEnumerable<String> listaPontosDias = PontoDAO.GetInstance().ConsultarPontos();
            string[] mensagem = new string[listaPontosDias.Count()];
            int count = 0;
            //string[] mensagem = new string[listaPontos.Length];
            foreach (String informacaoPontosDia in listaPontosDias)
            //for (int i = 0; i < listaPontos.Length; i++)
            {
                //mensagem[i] = string.Concat(listaPontos[i].Data.ToString("dd/MM/yyyy"), "  -  ");
                //mensagem[i] = string.Concat(mensagem[i], listaPontos[i].Data.ToString("hh:mm"), " - ");
                //mensagem[i] = string.Concat(mensagem[i], listaPontos[i].Data.ToString("hh:mm"), " - ");
                //mensagem[i] = string.Concat(mensagem[i], listaPontos[i].Data.ToString("hh:mm"), " - ");
                //mensagem[i] = string.Concat(mensagem[i], listaPontos[i].Data.ToString("hh:mm"));

                //mensagem[count] = string.Concat(p.Data.ToString("dd/MM/yyyy"), "  -  ");
                //mensagem[count] = string.Concat(mensagem[count], p.Data.ToString("hh:mm"));
                mensagem[count] = informacaoPontosDia;
                count++;
            }

            InitializeComponent();
            this.ListaPontos.ItemsSource = mensagem;
            lblHorasTrabalhadas.Text = "170";
            lblSaldoHoras.Text = "10";
        }
    }

}