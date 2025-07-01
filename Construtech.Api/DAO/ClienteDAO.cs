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
                await conexao.OpenAsync();
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

        public async Task<Cliente> GetNomeCliente(string Nome)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT P.CodPessoa, P.Nome, C.CodCliente FROM Pessoa P
                            INNER JOIN Cliente C
                            ON P.CodPessoa = C.CodPessoa
                            WHERE P.Nome LIKE '%' + @Nome + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", Nome);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Cliente>(sql, parameters);
                return result;
            }
            catch (Exception ex)
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
