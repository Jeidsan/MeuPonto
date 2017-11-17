using MeuPonto.Base;
using MeuPonto.DAO;
using MeuPonto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Controller
{
    public class EmpresaController : IDomainController<Empresa>
    {
        public void Adicionar(string cnpj, string nome)
        {
            Empresa empresa = new Empresa() { Cnpj = cnpj, Nome = nome };
            EmpresaDAO.GetInstance().Adicionar(empresa);
        }
    }
}
