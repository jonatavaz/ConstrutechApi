using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Equipamento
    {
        public int CodEquipamento { get; set; }

        public string NomeEquipamento { get; set; }

        public decimal CustoHora { get; set; }

        public bool Disponibilidade { get; set; }

        public bool Manutencao { get; set; }
        
        //EXTRA
        public string DisponibilidadeObra { get; set; }
    }
}
