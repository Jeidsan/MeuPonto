using System.Collections.Generic;

namespace MeuPonto.Base
{
    /// <summary>
    /// Define a interface mínima para o controle de acesso a dados da aplicação.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto de domínio para o qual será encapsulado o acesso aos dados.</typeparam>
    public interface IDomainObjectDAO<T> where T : DomainObject
    {
        /// <summary>
        /// Adiciona um objeto de domínio na base de dados da aplicação.
        /// </summary>
        /// <param name="domainObject">Objeto a ser adicionado na base de dados da aplicação.</param>
        void Adicionar(T domainObject);

        /// <summary>
        /// Atualiza os dados de um objeto de domínio na base de dados da aplicação.
        /// </summary>
        /// <param name="domainObject">Objeto de domínio a ser atualizado na base de dados da aplicação.</param>
        void Atualizar(T domainObject);

        /// <summary>
        /// Exclui um objeto de domínio da base de dados da aplicação.
        /// </summary>
        /// <param name="domainObject">Objeto de domínio a ser excluído.</param>
        void Excluir(T domainObject);

        /// <summary>
        /// Exclui um objeto de domínio da base de dados da aplicação.
        /// </summary>
        /// <param name="id">Identificador único do objeto de domínio a ser excluído da base de dados da aplicação.</param>
        void Excluir(int id);

        /// <summary>
        /// Consulta os objetos de domínio da aplicação.
        /// </summary>
        /// <returns>Lista dos objetos de domínio cadastrados na base de dados da aplicação.</returns>
        IEnumerable<T> Consultar();

        /// <summary>
        /// Consulta um objeto de domínio da aplicação.
        /// </summary>
        /// <param name="id">Identificador único do objeto de domínio que se deseja consultar.</param>
        /// <returns>O objeto de domínio requerido ou null caso o identificador não seja encontrado na base de dados.</returns>
        T Consultar(int id);
    }
}
