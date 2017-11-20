using MeuPonto.Base;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;

namespace MeuPonto.Model
{
    [Table("Usuario")]
    public class Usuario : DomainObject
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public TimeSpan InicioTrabalho { get; set; }
        public TimeSpan InicioAlmoco { get; set; }
        public TimeSpan TerminoAlmoco { get; set; }
        public TimeSpan TerminoTrabalho { get; set; }

        public string Cnpj { get; set; }
        public string Empresa { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //[OneToOne("JornadaTrabId")]
        //public JornadaTrabalho JornadaTrab { get; set; }

        //[OneToOne("EmpresaId")]
        //public Empresa Empresa { get; set; }
    }
}
