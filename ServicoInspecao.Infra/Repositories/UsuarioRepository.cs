using ServicoInspecao.Dominio.Entities;
using ServicoInspecao.Dominio.Interfaces.Repositories;
using ServicoInspecao.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void CreateUsuario(Usuario usuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Add(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        public Usuario GetByLogin(string login)
        {
            //conectando ao banco
            using (var sqlServerContext = new SqlServerContext())
            {
                //realiza a consulta no banco de dados
                return sqlServerContext.Usuario.FirstOrDefault(u => u.Login.Equals(login));
            }
        }

        public Usuario GetByAcesso(string login, string senha)
        {
            //conectando ao banco
            using (var sqlServerContext = new SqlServerContext())
            {
                //realiza a consulta no banco de dados
                return sqlServerContext.Usuario.FirstOrDefault(u => u.Login.Equals(login) && u.Senha.Equals(senha));
            }
        }
    }
}
