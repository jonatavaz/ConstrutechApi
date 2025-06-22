using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class ObraBLL
    {

        private readonly ObraDAO dao;

        public ObraBLL()
        {
            dao = new ObraDAO();
        }

        public async Task<bool> InsertObra(Obra obra)
        {
            return await dao.InsertObra(obra);
        }
    }
}
