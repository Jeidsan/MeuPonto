using MeuPonto.Base;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;

namespace MeuPonto.Model
{
    [Table("Ponto")]
    public class Ponto : DomainObject
    {
        public DateTime Data { get; set; }
        //public TimeSpan InicioTrabalho { get; set; }
        //public TimeSpan InicioAlmoco { get; set; }
        //public TimeSpan TerminoAlmoco { get; set; }
        //public TimeSpan TerminoTrabalho { get; set; }

        public Ponto()
        {

        }
        public Ponto(DateTime DataP)
        {
            this.Data = DataP;
        }
        //public Ponto(DateTime DataP, TimeSpan InicioTrabalhoP, TimeSpan InicioAlmocoP, TimeSpan TerminoAlmocoP, TimeSpan TerminoTrabalhoP)
        //{
        //    this.Data = DataP;
        //    this.InicioTrabalho = InicioTrabalhoP;
        //    this.InicioAlmoco = InicioAlmocoP;
        //    this.TerminoAlmoco = TerminoAlmocoP;
        //    this.TerminoTrabalho = TerminoTrabalhoP;
        //}
    }
}
