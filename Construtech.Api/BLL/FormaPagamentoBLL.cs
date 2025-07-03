using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class FormaPagamentoBLL
    {
        private readonly FormaPagamentoDAO dao;

        public FormaPagamentoBLL()
        {
            dao = new FormaPagamentoDAO();
        }

        public async Task<FormaPagamento> GetFormaPagamento(string Nome)
        {
            return await dao.GetFormaPagamento(Nome);
        }
    }
}
