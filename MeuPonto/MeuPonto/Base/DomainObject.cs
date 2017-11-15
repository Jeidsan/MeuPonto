using SQLite.Net.Attributes;

namespace MeuPonto.Base
{
    /// <summary>
    /// Interface mínima para objetos de domínio da aplicação.
    /// </summary>
    public abstract class DomainObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}

