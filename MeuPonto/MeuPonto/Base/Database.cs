using MeuPonto.Model;
using SQLite.Net;
using System;
using System.IO;
using Xamarin.Forms;

namespace MeuPonto.Base
{
    public static class Database
    {
        private const string DATABASE_NAME = "MeuPonto.db";
        private static IConfig config = DependencyService.Get<IConfig>();

        /// <summary>
        /// Cria a base de dados da aplicação.
        /// </summary>        
        public static void CriarDatabase()
        {
            try
            {  
                using (SQLiteConnection conexao = GetConnection())
                {
                    conexao.CreateTable<Usuario>();
                    conexao.CreateTable<Ponto>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar criar a base de dados da aplicação. Por favor, tente reiniciar o aplicativo.", ex);
            }
        }

        /// <summary>
        /// Adiciona um novo objeto de domínio à base de dados da aplicação.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto de domínio a ser adicionado à base de dados da aplicação.</typeparam>
        /// <param name="domainObject">Objeto de domínio a ser adicionado à base de dados da aplicação.</param>
        public static void Adicionar<T>(T domainObject) where T : DomainObject
        {
            try
            {
                using (SQLiteConnection conexao = GetConnection())
                {
                    conexao.Insert(domainObject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um registro na base de dados. Por favor, tente novamente.", ex);
            }
        }

        /// <summary>
        /// Exclui um objeto de domínio da base de dados.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto de domínio a ser excluído da base de dados da aplicação.</typeparam>
        /// <param name="domainObject">Objeto de domínio a ser excluído da base de dados da aplicação.</param>
        public static void Excluir<T>(T domainObject) where T : DomainObject
        {
            try
            {
                using (SQLiteConnection conexao = GetConnection())
                {
                    conexao.Delete(domainObject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir um registro na base de dados. Por favor, tente novamente.", ex);
            }
        }

        /// <summary>
        /// Atualiza um objeto de domínio na base de dados da aplicação.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto de domínio a ser atualizado na base de dados da aplicação.</typeparam>
        /// <param name="domainObject">Objeto de domínio a ser atualizado na base de dados da aplicação.</param>
        public static void Atualizar<T>(T domainObject) where T : DomainObject
        {
            try
            {
                using (SQLiteConnection conexao = GetConnection())
                {
                    conexao.Update(domainObject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar atualizar um registro na base de dados. Por favor, tente novamente.", ex);
            }
        }

        /// <summary>
        /// Executa um comando SQL na base de dados da aplicação.
        /// </summary>
        /// <param name="comando">Comando a ser executado na base de dados da aplicação.</param>
        /// <param name="parametros">Parâemtros a serem utilizados no comando.</param>
        public static void ExecutarComando(string comando, params object[] parametros)
        {
            try
            {
                using (SQLiteConnection conexao = GetConnection())
                {
                    conexao.Execute(comando, parametros);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar executar um comando na base de dados. Por favor, tente novamente.", ex);
            }
        }

        /// <summary>
        /// Fornece uma instância de coneção à base de dados da aplicação.
        /// </summary>
        /// <returns>Instância de conexão à base de dados da aplicação.</returns>
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(config.Plataforma, Path.Combine(config.DiretorioSQLite, DATABASE_NAME));
        }
    }
}
