using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using POJO;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAO dao;

        public UsuarioBLL()
        {
            dao = new UsuarioDAO();
        }
        public async Task<Usuario> LoginCPF(string CPF)
        {
            return await dao.LoginCPF(CPF);
        }
    }
}
