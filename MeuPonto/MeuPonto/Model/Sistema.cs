using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Model
{
    public static class Sistema
    {
        private static Usuario fUsuarioLogado;

        public static Usuario UsuarioLogado
        {
            get { return fUsuarioLogado; }
            set { fUsuarioLogado = value; }
        }
    }
}
