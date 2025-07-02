using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class ObraEquipamento
    {
        public int CodObraEquipamento { get; set; }
        public int CodObra { get; set; }
        public int CodEquipamento { get; set; }
        public string DataAlocacao { get; set; }
        public string? DataRetorno { get; set; }
        public string NomeObra { get; set; }
        public string NomeEquipamento { get; set; }
        public decimal CustoHora { get; set; }
        public string DisponibilidadeObra { get; set; }
        public bool Manutencao { get; set; }
    }
}
