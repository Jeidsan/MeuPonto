using MeuPonto.Base;
using MeuPonto.DAO;
using MeuPonto.Model;
using System;

namespace MeuPonto.Controller
{
    public class UsuarioController : IDomainController<Usuario>
    {
        public bool Autenticar(string login, string senha)
        {
            Usuario usuario = Database.GetConnection().FindWithQuery<Usuario>("SELECT TOP 1 * FROM Usuario WHERE login = ? AND senha = ?", login, senha);
            return (usuario != null);
        }

        public void Cadastrar(string nome, string login, string senha, string cpf, string telefone, string email, TimeSpan inicioJornada, TimeSpan inicioAlmoco, TimeSpan finalAlmoco, TimeSpan finalJornada)
        {
            //JornadaTrabalho jornada = new JornadaTrabalho()
            //{
            //    InicioTrabalho = inicioJornada,
            //    InicioAlmoco = inicioAlmoco,
            //    TerminoAlmoco = finalAlmoco,
            //    TerminoTrabalho = finalJornada
            //};

            //JornadaTrabalhoDAO.GetInstance().Adicionar(jornada);

            //Usuario usuario = new Usuario()
            //{
            //    Nome = nome,
            //    Login = login,
            //    Senha = senha,
            //    Cpf = cpf,
            //    Telefone = telefone,
            //    Email = email,
            //    JornadaTrab = jornada
            //};

            //UsuarioDAO.GetInstance().Adicionar(usuario);
        }
    }
}
