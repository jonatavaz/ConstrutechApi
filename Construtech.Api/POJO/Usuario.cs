using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Usuario
    {
        public int CodUsuario {  get; set; }
        public int CodPessoa {  get; set; }
        public string Senha {  get; set; }
        public bool Administrador {  get; set; }
        public bool Ativo { get; set; }
    }
}
