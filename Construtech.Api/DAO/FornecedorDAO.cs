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
    public class FornecedorDAO
    {
        public async Task<List<Fornecedor>> GetListFornecedores()
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT F.CodFornecedor, P.Nome, F.Avaliacao, F.DataHora_Cadastro FROM Fornecedor F
                        INNER JOIN Pessoa P
                        ON F.CodPessoa = P.CodPessoa
                        ";

            try
            {
                var result = await conexao.QueryAsync<Fornecedor>(sql);
                return [.. result];
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

        public async Task<int> InsertFornecedor(Fornecedor fornecedor)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"EXEC PR_Fornecedor @Nome, @CPF, @Nascimento, @Senha, @Ativo, @Administrador, @Email, @Telefone1, @Historico, @Avaliacao";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", fornecedor.Nome);
            parameters.Add("@CPF", fornecedor.CPF);
            parameters.Add("@Nascimento", fornecedor.Nascimento);
            parameters.Add("@Senha", fornecedor.Senha);
            parameters.Add("@Ativo", 1);
            parameters.Add("@Administrador", 1);
            parameters.Add("@Email", fornecedor.Email);
            parameters.Add("@Telefone1", fornecedor.Telefone);
            parameters.Add("@Historico", fornecedor.Historico);
            parameters.Add("@Avaliacao", fornecedor.Avaliacao);

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
