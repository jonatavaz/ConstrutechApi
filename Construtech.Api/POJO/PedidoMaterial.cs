using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class PedidoMaterial
    {
        public int CodPedidoMaterial { get; set; }
        public int CodObra { get; set; }
        public int CodMaterial { get; set; }
        public decimal Quantidade { get; set; }

        public Material Material { get; set; }
        public Obra Obra { get; set; }
    }
}
