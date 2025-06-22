using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Obra
    {
        public int CodObra {  get; set; }
        public short CodCliente {  get; set; }
        public string Nome {  get; set; }
        public string Endereco {  get; set; }
        public string Tipo {  get; set; }
        public string PrazoExecucao {  get; set; }
        public string EstagioAtual {  get; set; }
        public string? Detalhes {  get; set; }
    }
}
