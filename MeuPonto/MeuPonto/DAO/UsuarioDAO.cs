using MeuPonto.Base;
using MeuPonto.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuPonto.DAO
{
    /// <summary>
    /// Encapsula o acesso aos dados da tabela Usuário no banco de dados da aplicação.
    /// </summary>
    public class UsuarioDAO : IDomainObjectDAO<Usuario>
    {
        private UsuarioDAO() { }

        private static UsuarioDAO uniqueInstance;

        public static UsuarioDAO GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new UsuarioDAO();
            return uniqueInstance;
        }

        public void Adicionar(Usuario domainObject)
        {
            Database.Adicionar<Usuario>(domainObject);
        }

        public void Atualizar(Usuario domainObject)
        {
            Database.Atualizar<Usuario>(domainObject);
        }

        public IEnumerable<Usuario> Consultar()
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    return conexao.Table<Usuario>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar a lista de usuários na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public Usuario Consultar(int id)
        {
            try
            {
                using (SQLiteConnection conexao = Database.GetConnection())
                {
                    List<Usuario> listaUsuarios = conexao.Query<Usuario>("SELECT * FROM Usuario WHERE Id=?", id);
                    return listaUsuarios.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar um usuário na base de dados. Por favor, tente realizar a tarefa novamente.", ex);
            }
        }

        public void Excluir(Usuario domainObject)
        {
            Database.Excluir<Usuario>(domainObject);
        }

        public void Excluir(int id)
        {
            Database.ExecutarComando("DELETE FROM Usuario WHERE Id=?", id);
        }

        public Usuario Autenticar(string login, string senha)
        {
            Usuario usuario = Database.GetConnection().FindWithQuery<Usuario>("SELECT * FROM Usuario WHERE login = ? AND senha = ?", login, senha);
            return usuario;
        }
    }
}
