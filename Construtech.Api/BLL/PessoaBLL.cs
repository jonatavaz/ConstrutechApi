using DAO;
using DTO;
using POJO;

namespace BLL
{
    public class PessoaBLL
    {
        private readonly PessoaDAO dao;

        public PessoaBLL()
        {
            dao = new PessoaDAO();
        }

        public async Task<Pessoa> GetPessoa(string Email, string Senha)
        {
            return await dao.GetPessoa(Email, Senha);
        }

        public async Task<bool> InsertPessoa(Pessoa pessoa)
        { 
            return await dao.InsertPessoa(pessoa);
        }
    }
}
