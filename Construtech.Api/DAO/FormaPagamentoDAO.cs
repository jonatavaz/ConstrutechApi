using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using POJO;

namespace DAO
{
    public class FormaPagamentoDAO
    {
        public async Task<FormaPagamento> GetFormaPagamento(string Nome)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT CodFormaPagamento, Nome  FROM FormaPagamento WHERE Nome LIKE '%' + @Nome + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", Nome);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<FormaPagamento>(sql, parameters);
                return result;
            }
            catch (Exception ex) {
                string e = ex.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
