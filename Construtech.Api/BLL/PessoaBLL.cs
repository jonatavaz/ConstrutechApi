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

        public async Task<Pessoa> GetPessoa(short CodPessoa)
        {
            return await dao.GetPessoa(CodPessoa);
        }

        public async Task<bool> InsertPessoa(PessoaDTO pessoaDTO)
        {
            var pessoa = new Pessoa
            {
                Nome = pessoaDTO.Nome,
                CPF = pessoaDTO.CPF,
                Nascimento = pessoaDTO.Nascimento
            };

            return await dao.InsertPessoa(pessoa);
        }
    }
}
