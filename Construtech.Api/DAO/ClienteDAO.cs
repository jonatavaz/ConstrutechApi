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
    public class ClienteDAO
    {
        public async Task<List<Cliente>> GetListClientes()
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT C.CodCliente, P.Nome FROM Cliente C
                                INNER JOIN Pessoa P ON C.CodPessoa = P.CodPessoa";

            try
            {
                var result = await conexao.QueryAsync<Cliente>(sql);
                return result.ToList();
            
            }catch(Exception ex)
            {
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
