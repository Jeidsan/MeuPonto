using SQLite.Net.Interop;

namespace MeuPonto.Base
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
