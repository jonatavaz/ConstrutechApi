using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using POJO;

namespace DAO
{
    public class PessoaDAO
    {
        public async Task<Pessoa> GetPessoa(short CodPessoa)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"select * from Pessoa WHERE CodPessoa = @CodPessoa";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CodPessoa", CodPessoa);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Pessoa>(sql, parameters);
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

        public async Task<bool> InsertPessoa(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"INSERT INTO Pessoa(Nome, CPF, Nascimento, DataHora_Cadastro, CodPessoa_Cadastro)
                            VALUES(@Nome, @CPF, @Nascimento, GETDATE(), 0)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", pessoa.Nome);
            parameters.Add("@CPF", pessoa.CPF);
            parameters.Add("@Nascimento", pessoa.Nascimento);

            try
            {
                var result = await conexao.ExecuteAsync(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
