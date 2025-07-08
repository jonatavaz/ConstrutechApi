using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Fornecedor
    {
        public int CodFornecedor { get; set; }
        public string Historico { get; set; }
        public string Avaliacao { get; set; }
        public string DataHora_Cadastro { get; set; }

        public string Nome { get; set; }

         public string CPF { get; set; }
         public string Nascimento { get; set; }
         public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
