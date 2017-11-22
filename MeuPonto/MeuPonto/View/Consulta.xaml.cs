using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeuPonto.Model;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        public Consulta()
        {

            Ponto[] listaPontos = new Ponto[5];
            listaPontos[0] = new Ponto(DateTime.Today, new TimeSpan());
            listaPontos[1] = new Ponto(DateTime.Today, new TimeSpan());
            listaPontos[2] = new Ponto(DateTime.Today, new TimeSpan());
            listaPontos[3] = new Ponto(DateTime.Today, new TimeSpan());
            listaPontos[4] = new Ponto(DateTime.Today, new TimeSpan());

            string[] mensagem = new string[listaPontos.Length];
            for (int i = 0; i < listaPontos.Length; i++)
            {
                mensagem[i] = string.Concat(listaPontos[i].DiaPonto.ToString("dd/MM/yyyy"), " - ", listaPontos[i].HoraPonto.ToString());
            }

            InitializeComponent();
            this.ListaPontos.ItemsSource = mensagem;
        }
    }
}