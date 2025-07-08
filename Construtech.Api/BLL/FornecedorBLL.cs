using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class FornecedorBLL
    {
        private readonly FornecedorDAO dao;

        public FornecedorBLL()
        {
            dao = new FornecedorDAO();
        }

        public async Task<List<Fornecedor>> GetListFornecedores()
        {
            return await dao.GetListFornecedores();
        }

        public async Task<int> InsertFornecedor(Fornecedor fornecedor)
        {
            return await dao.InsertFornecedor(fornecedor);
        }
    }
}
