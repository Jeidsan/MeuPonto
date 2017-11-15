using MeuPonto.Base;
using SQLite;
using SQLite.Net.Attributes;

namespace MeuPonto.Model
{
    [Table("Empresa")]
    public class Empresa : DomainObject
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
    }
}
