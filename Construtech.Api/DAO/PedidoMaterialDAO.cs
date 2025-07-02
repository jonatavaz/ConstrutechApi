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
    public class PedidoMaterialDAO
    {
        public async Task<Material> GetNomeMatrial(string Nome)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT CodMaterial, Nome FROM Material WHERE Nome LIKE '%' + @Nome + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nome", Nome);

            try
            {
                var result = await conexao.QueryFirstOrDefaultAsync<Material>(sql, parameters);
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


        public async Task<bool> UpInsertPedidoMaterial(PedidoMaterial pedidoMaterial)
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"IF NOT EXISTS (SELECT 1 FROM PedidoMaterial WHERE CodPedidoMaterial = @CodPedidoMaterial)
                            BEGIN
                                INSERT INTO PedidoMaterial(CodObra, CodMaterial, Quantidade,  DataHora_Cadastro, CodPessoa_Cadastro)
                                    VALUES(@CodObra, @CodMaterial, @Quantidade,  GETDATE(), 0)
                            END
                            ELSE
                            BEGIN
                                UPDATE PedidoMaterial SET @Quantidade = @Quantidade
                            END";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CodPedidoMaterial", pedidoMaterial.CodPedidoMaterial);
            parameters.Add("@CodObra", pedidoMaterial.CodObra);
            parameters.Add("@CodMaterial", pedidoMaterial.CodMaterial);
            parameters.Add("@Quantidade", pedidoMaterial.Quantidade);

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
