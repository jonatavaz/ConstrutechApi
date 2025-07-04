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
            parameters.Add("@Nome", obra.NomeObra);
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

        public async Task<List<Obra>> GetObras()
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = "SELECT CodObra, CodCliente, Nome AS NomeObra, Endereco, Tipo, PrazoExecucao, EstagioAtual, Detalhes FROM Obra";

            try
            {
                var result = await conexao.QueryAsync<Obra>(sql);
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

        public async Task<Obra> GetObra(string Nome)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = "SELECT CodObra, Nome AS NomeObra FROM Obra WHERE  Nome Like'%' + @Nome + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", Nome);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Obra>(sql, parameters);
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
