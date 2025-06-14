using DAO;
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

        public async Task<Pessoa> GetPessoa(string CPF, string Senha)
        {
            var user = await dao.LoginCPF(CPF);

            var senha = Utilitarios.VerificaSenha(Senha, user.Senha);
            if(senha)
                return await dao.GetPessoa(CPF, user.Senha);
            else
                return null;
        }
        public async Task<Usuario> LoginCPF(string CPF)
        {
            return await dao.LoginCPF(CPF);
        }
        public async Task<int> InsertPessoa(Pessoa pessoa)
        {
            

            var senha = Utilitarios.HashPassword256(pessoa.Usuario.Senha);
            pessoa.Usuario.Senha = senha;
            return await dao.InsertPessoa(pessoa);
        }
    }
}
