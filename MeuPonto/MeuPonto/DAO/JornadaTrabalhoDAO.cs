using MeuPonto.Base;
using MeuPonto.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuPonto.DAO
{
    /// <summary>
    /// Encapsula o acesso aos dados da tabela JornadaTrabalho no banco de dados da aplicação.
    /// </summary>
    public class JornadaTrabalhoDAO : IDomainObjectDAO<JornadaTrabalho>
    {
        private JornadaTrabalhoDAO() { }

        private static JornadaTrabalhoDAO uniqueInstance;

        public static JornadaTrabalhoDAO GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new JornadaTrabalhoDAO();
            return uniqueInstance;
        }

        public void Adicionar(JornadaTrabalho domainObject)
        {
            Database.Adicionar<JornadaTrabalho>(domainObject);
        }

        public void Atualizar(JornadaTrabalho domainObject)
        {
            Database.Atualizar<JornadaTrabalho>(domainObject);
        }

        public IEnumerable<JornadaTrabalho> Consultar()
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    return conexao.Table<JornadaTrabalho>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar a lista de jornadas de trabalho na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public JornadaTrabalho Consultar(int id)
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    List<JornadaTrabalho> listaJornadaTrabalhos = conexao.Query<JornadaTrabalho>("SELECT * FROM JornadaTrabalho WHERE Id=?", id);
                    return listaJornadaTrabalhos.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar uma jornada de trabalho na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public void Excluir(JornadaTrabalho domainObject)
        {
            Database.Excluir<JornadaTrabalho>(domainObject);
        }

        public void Excluir(int id)
        {
            Database.ExecutarComando("DELETE FROM JornadaTrabalho WHERE Id=?", id);
        }
    }
}
