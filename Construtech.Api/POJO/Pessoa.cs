namespace POJO
{
    public class Pessoa
    {
        public int CodPessoa { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Nascimento { get; set; }

        public Usuario Usuario { get; set; }

        public Contato Contato { get; set; }
        public Cliente Cliente { get; set; }
    }
}
