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
    public class ObraEquipamentoDAO
    {
        public async Task<Equipamento> GetCodEquipamento(string Nome)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT CodEquipamento, Nome FROM Equipamento WHERE Nome LIKE '%' + @Nome + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", Nome);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Equipamento>(sql, parameters);
                return result;
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

        public async Task<bool> UpInsertObraEquipamento(ObraEquipamento obraEquipamento)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"IF NOT EXISTS (SELECT 1 FROM ObraEquipamento WHERE CodObra = @CodObra AND CodEquipamento = @CodEquipamento AND DataRetorno = NULL)
                            BEGIN
                                INSERT INTO ObraEquipamento(CodObra, CodEquipamento, DataAlocacao, DataRetorno)
                                    VALUES(@CodObra, @CodEquipamento, @DataAlocacao, @DataRetorno)
                            END
                            ELSE
                            BEGIN
                                UPDATE ObraEquipamento SET  @DataAlocacao = @DataAlocacao, DataRetorno = @DataRetorno WHERE CodObra = @CodObra AND CodEquipamento = @CodEquipamento
                            END";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CodObra", obraEquipamento.CodObra);
            parameters.Add("@CodEquipamento", obraEquipamento.CodEquipamento);
            parameters.Add("@DataAlocacao", obraEquipamento.DataAlocacao);
            parameters.Add("@DataRetorno", obraEquipamento.DataRetorno);

            try
            {
                var result = await conexao.ExecuteAsync(sql, parameters);
                return true;
            }catch(Exception ex)
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
