using MeuPonto.Base;
using MeuPonto.Model;
using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuPonto.DAO
{
    /// <summary>
    /// Encapsula o acesso aos dados da tabela Empresa no banco de dados da aplicação.
    /// </summary>
    public class EmpresaDAO : IDomainObjectDAO<Empresa>
    {
        private EmpresaDAO() { }

        private static EmpresaDAO uniqueInstance;

        public static EmpresaDAO GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new EmpresaDAO();
            return uniqueInstance;
        }

        public void Adicionar(Empresa domainObject)
        {
            Database.Adicionar<Empresa>(domainObject);
        }

        public void Atualizar(Empresa domainObject)
        {
            Database.Atualizar<Empresa>(domainObject);
        }

        public IEnumerable<Empresa> Consultar()
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    return conexao.Table<Empresa>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar a lista de empresas na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public Empresa Consultar(int id)
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    List<Empresa> listaEmpresas = conexao.Query<Empresa>("SELECT * FROM Empresa WHERE Id=?", id);
                    return listaEmpresas.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar uma empresa na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public void Excluir(Empresa domainObject)
        {
            Database.Excluir<Empresa>(domainObject);
        }

        public void Excluir(int id)
        {
            Database.ExecutarComando("DELETE FROM Empresa WHERE Id=?", id);
        }
    }
}
