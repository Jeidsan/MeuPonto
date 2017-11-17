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


        [OneToOne("JornadaTrabId")]
        public JornadaTrabalho JornadaTrab { get; set; }
        
        [OneToOne("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}
