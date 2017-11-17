using MeuPonto.Base;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

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

        [ForeignKey(typeof(JornadaTrabalho))]
        public int JornadaTrabId { get; set; }

        [OneToOne]
        public virtual JornadaTrabalho JornadaTrab { get; set; }

        [ForeignKey(typeof(Empresa))]
        public int EmpresaId { get; set; }
        [OneToOne]
        public virtual Empresa Empresa { get; set; }
    }
}
