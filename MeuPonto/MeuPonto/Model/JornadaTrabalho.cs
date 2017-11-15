using MeuPonto.Base;
using SQLite.Net.Attributes;
using System;

namespace MeuPonto.Model
{
    [Table("JornadaTrabalho")]
    public class JornadaTrabalho : DomainObject
    {        
        public DateTime InicioTrabalho { get; set; }
        public DateTime InicioAlmoco { get; set; }
        public DateTime TerminoAlmoco { get; set; }
        public DateTime TerminoTrabalho { get; set; }

    }
}
