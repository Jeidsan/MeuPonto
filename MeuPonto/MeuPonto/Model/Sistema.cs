using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Model
{
    public static class Sistema
    {
        static Usuario usuarioLogado;

        public static Usuario UsuarioLogado
        {
            get
            {
                return usuarioLogado;
            }
            set
            {
                usuarioLogado = value;
            }
        }
    }
}
