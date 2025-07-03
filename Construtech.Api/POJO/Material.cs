using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Material
    {
        public int CodMaterial { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        

        //Extra
        public int CodObra {get; set;}
        public string NomeObra {get; set;}

        public int Unidade { get; set; }
    }
}
