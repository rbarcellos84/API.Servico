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
    public class InspecaoRepository : IInspecaoRepository
    {
        public void CreateInspecao(Inspecao inspecao)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Add(inspecao);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Inspecao> GetAllInspecao(Guid idUsuario)
        {
            //conectando ao banco
            using (var sqlServerContext = new SqlServerContext())
            {
                //realiza a consulta no banco de dados
                return sqlServerContext.Inspecao.Where(i => i.IdUsuario == idUsuario).OrderByDescending(i => i.DataCadastro).ToList();
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
    }
}
