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
    public class ObraDAO
    {
        public async Task<bool> InsertObra(Obra obra)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"INSERT INTO Obra(CodCliente, Nome, Endereco, Tipo, PrazoExecucao, EstagioAtual, Detalhes, CodPessoa_Cadastro)
                                VALUES(@CodCliente, @Nome, @Endereco, @Tipo, @PrazoExecucao, @EstagioAtual, @Detalhes, 0);";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CodCliente", obra.CodCliente);
            parameters.Add("@Nome", obra.Nome);
            parameters.Add("@Endereco", obra.Endereco);
            parameters.Add("@Tipo", obra.Tipo);
            parameters.Add("@PrazoExecucao", obra.PrazoExecucao);
            parameters.Add("@EstagioAtual", obra.EstagioAtual);
            parameters.Add("@Detalhes", obra.Detalhes);

            try
            {
                var result = await conexao.ExecuteAsync(sql, parameters);
                return result > 0;
            }
            catch (Exception ex) { 
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
