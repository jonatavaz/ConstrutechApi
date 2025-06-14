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
    public class PessoaDAO
    {
        public async Task<Pessoa> GetPessoa(string CPF, string Senha)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT * FROM Pessoa P 
                                INNER JOIN Usuario U ON P.CodPessoa = U.CodPessoa
                           WHERE P.CPF = @CPF AND U.Senha = @Senha";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CPF", CPF);
            parameters.Add("@Senha", Senha);

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

        public async Task<int> InsertPessoa(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"EXEC PR_CadastrarPessoa @Nome, @CPF, @Nascimento, @Senha, @Ativo, @Administrador, @Email, @Telefone1";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", pessoa.Nome);
            parameters.Add("@CPF", pessoa.CPF);
            parameters.Add("@Nascimento", pessoa.Nascimento);
            parameters.Add("@Senha", pessoa.Usuario.Senha);
            parameters.Add("@Ativo", 1);
            parameters.Add("@Administrador", 1);
            parameters.Add("@Email", pessoa.Contato.Email);
            parameters.Add("@Telefone1", pessoa.Contato.Telefone1);

            try
            {
                var result = await conexao.ExecuteAsync(sql, parameters);
                return result;
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return 0;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
