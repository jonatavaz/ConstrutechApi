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
    public class PagamentoDAO
    {
        public async Task<List<dynamic>> GetListPagamentos()
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT O.Nome, P.DataHoraPagamento, P.ValorPago from Pagamento P
                                INNER JOIN Obra O
                                ON P.CodObra = O.CodObra
                                INNER JOIN FormaPagamento FP
                                ON P.CodFormaPagamento = Fp.CodFormaPagamento";
            try
            {
                var result = await conexao.QueryAsync<dynamic>(sql);
                return [.. result];
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

        public async Task<bool> InsertPagamento(Pagamento pagamento)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"INSERT INTO Pagamento(CodFormaPagamento, CodObra, ValorPago, DataHoraPagamento)
                                VALUES(@CodFormaPagamento, @CodObra, @ValorPago, GETDATE());";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CodFormaPagamento", pagamento.CodFormaPagamento);
            parameters.Add("@CodObra", pagamento.CodObra);
            parameters.Add("@ValorPago", pagamento.ValorPago);

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
