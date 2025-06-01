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
        public async Task<Pessoa> GetPessoa(string Email, string Senha)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT * FROM Pessoa P INNER JOIN Usuario U ON P.CodPessoa = U.CodPessoa
                            INNER JOIN Contato C ON P.CodPessoa = C.CodPessoa
                            WHERE C.Email = @Email AND U.Senha = @Senha";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email", Email);
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

        public async Task<bool> InsertPessoa(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"EXEC PR_CadastrarPessoa @Nome, @CPF, @Nascimento, @CodPessoa_Cadastro, @Senha, @Ativo, @Administrador, @Email, @Telefone1";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", pessoa.Nome);
            parameters.Add("@CPF", pessoa.CPF);
            parameters.Add("@Nascimento", pessoa.Nascimento);
            parameters.Add("@CodPessoa_Cadastro", 0);
            parameters.Add("@Senha", pessoa.Usuario.Senha);
            parameters.Add("@Ativo", 1);
            parameters.Add("@Administrador", 1);
            parameters.Add("@Email", pessoa.Contato.Email);
            parameters.Add("@Telefone1", pessoa.Contato.Telefone1);

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
