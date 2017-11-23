using MeuPonto.Base;
using MeuPonto.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuPonto.DAO
{
    /// <summary>
    /// Encapsula o acesso aos dados da tabela Ponto no banco de dados da aplicação.
    /// </summary>
    public class PontoDAO : IDomainObjectDAO<Ponto>
    {
        private PontoDAO() { }

        private static PontoDAO uniqueInstance;

        public static PontoDAO GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new PontoDAO();
            return uniqueInstance;
        }

        public void Adicionar(Ponto domainObject)
        {
            Database.Adicionar<Ponto>(domainObject);
        }

        public void Atualizar(Ponto domainObject)
        {
            Database.Atualizar<Ponto>(domainObject);
        }

        public IEnumerable<Ponto> Consultar()
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    return conexao.Table<Ponto>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar a lista de batidas de pontos na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public IEnumerable<String> ConsultarPontos()
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    IEnumerable<String> listaPontos = conexao.Query<String>("select strftime('%d/%m/%Y', Data) || '  -  ' || group_concat(strftime('%H:%M', Data), ' - ') as pontos from Ponto group by date(Data)");
                    return listaPontos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar a lista de batidas de pontos na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public Ponto Consultar(int id)
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    List<Ponto> listaPontos = conexao.Query<Ponto>("SELECT * FROM Ponto WHERE Id=?", id);
                    return listaPontos.FirstOrDefault(); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar um registro de ponto na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public void Excluir(Ponto domainObject)
        {
            Database.Excluir<Ponto>(domainObject);
        }

        public void Excluir(int id)
        {
            Database.ExecutarComando("DELETE FROM Ponto WHERE Id=?", id);
        }

    }
}
