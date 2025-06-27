using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAO dao;

        public ClienteBLL()
        {
            dao = new ClienteDAO();
        }

        public async Task<List<Cliente>> GetListClientes()
        {
            return await dao.GetListClientes();
        }

        public async Task<Cliente> GetNomeCliente(string Nome)
        {
            return await dao.GetNomeCliente(Nome);
        }
    }
}
