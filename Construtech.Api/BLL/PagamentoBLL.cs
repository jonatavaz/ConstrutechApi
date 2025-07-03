using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class PagamentoBLL
    {
        private readonly PagamentoDAO dao;

        public PagamentoBLL()
        {
            dao = new PagamentoDAO();
        }

        public async Task<bool> InsertPagamento(Pagamento pagamento)
        {
            return await dao.InsertPagamento(pagamento);
        }
    }
}
