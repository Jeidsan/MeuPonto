using MeuPonto.Base;
using SQLite.Net.Attributes;
using System;
using SQLiteNetExtensions.Attributes;

namespace MeuPonto.Model
{
    [Table("Ponto")]
    public class Ponto : DomainObject
    {
        public DateTime Data { get; set; }
        public TimeSpan InicioTrabalho { get; set; }
        public TimeSpan InicioAlmoco { get; set; }
        public TimeSpan TerminoAlmoco { get; set; }
        public TimeSpan TerminoTrabalho { get; set; }

    }
}
