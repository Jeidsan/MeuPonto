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

    }
}
