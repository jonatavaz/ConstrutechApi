using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class ObraEquipamentoBLL
    {
        private readonly ObraEquipamentoDAO dao;

        public ObraEquipamentoBLL()
        {
            dao = new ObraEquipamentoDAO();
        }
        public async Task<Equipamento> GetCodEquipamento(string Nome)
        {
            return await dao.GetCodEquipamento(Nome);
        }

        public async Task<List<ObraEquipamento>> GetListObraEquipamento(int CodObra)
        {
            return await dao.GetListObraEquipamento(CodObra);
        }

        public async Task<bool> UpInsertObraEquipamento(ObraEquipamento obraEquipamento)
        {
            return await dao.UpInsertObraEquipamento(obraEquipamento);
        }
    }
}
