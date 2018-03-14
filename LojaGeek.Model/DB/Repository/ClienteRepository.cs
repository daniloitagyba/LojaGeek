using LojaGeek.Model.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGeek.Model.DB.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>
    {
        public ClienteRepository(ISession session) : base(session) { }

        public IList<Cliente> GetAllByName(String nome)
        {
            try
            {
                return this.Session.Query<Cliente>()
                           .Where(w => w.Nome.ToLower() == nome.Trim().ToLower()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pessoa pelo nome", ex);
            }
        }
    }
}
