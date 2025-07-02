using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class PedidoMaterialBLL
    {
        private readonly PedidoMaterialDAO dao;

        public PedidoMaterialBLL()
        {
            dao = new PedidoMaterialDAO();
        }

        public async Task<Material> GetNomeMatrial(string Nome)
        {
            return await dao.GetNomeMatrial(Nome);
        }

        public async Task<bool> UpInsertPedidoMaterial(PedidoMaterial pedidoMaterial)
        {
            return await dao.UpInsertPedidoMaterial(pedidoMaterial);
        }
    }
}
