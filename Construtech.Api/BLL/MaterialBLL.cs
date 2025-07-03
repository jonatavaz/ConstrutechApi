using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class MaterialBLL
    {
        private readonly MaterialDAO dao;

        public MaterialBLL()
        {
            dao = new MaterialDAO();
        }
        public async Task<List<Material>> GetListMateriais()
        {
            return await dao.GetListMateriais();
        }
    }
}
