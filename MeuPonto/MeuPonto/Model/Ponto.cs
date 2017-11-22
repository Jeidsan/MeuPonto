using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Model
{
    public class Ponto
    {
        public DateTime DiaPonto { get; set; }
        public TimeSpan HoraPonto { get; set; }

        public Ponto()
        {

        }

        public Ponto(DateTime DiaPontoP, TimeSpan HoraPontoP)
        {
            this.DiaPonto = DiaPontoP;
            this.HoraPonto = HoraPontoP;
        }
    }
}
