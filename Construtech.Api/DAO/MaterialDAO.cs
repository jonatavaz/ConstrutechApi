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
    public class MaterialDAO
    {
        public async Task<List<Material>> GetListMateriais()
        {
            SqlConnection conexao = new SqlConnection(_Conexao.StringDeConexao);

            string sql = @"SELECT M.CodMaterial, M.Nome, O.CodObra, O.Nome AS NomeObra, M.Unidade 
                            FROM PedidoMaterial PM
                            INNER JOIN Obra O ON PM.CodObra = O.CodObra
                            INNER JOIN Material M ON PM.CodMaterial = M.CodMaterial";

            try
            {
                var result = await conexao.QueryAsync<Material>(sql);
                return result.ToList();
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
    }
}
