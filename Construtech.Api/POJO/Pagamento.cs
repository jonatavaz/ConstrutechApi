using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Pagamento
    {
        public int CodPagamento { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodObra { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataHoraPagamento { get; set; }

        public FormaPagamento FormaPagamento { get; set; }
        public Obra Obra { get; set; }
    }
}
