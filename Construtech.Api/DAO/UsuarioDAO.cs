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
    public class UsuarioDAO
    {
        public async Task<Usuario> LoginCPF(string CPF)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT * FROM Usuario U
                                INNER JOIN Pessoa P ON U.CodPessoa = P.CodPessoa
                           WHERE P.CPF = @CPF";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CPF", CPF);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Usuario>(sql, parameters);
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
