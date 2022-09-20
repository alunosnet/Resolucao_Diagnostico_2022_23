using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolucao_Diagnostico_2022_23
{
    public class Movimento
    {

        public Aluno Aluno { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoMovimento { get; set; }

        public Movimento(Aluno aluno, DateTime dataHora, string tipoMovimento)
        {
            Aluno = aluno;
            DataHora = dataHora;
            TipoMovimento = tipoMovimento;
        }
    }
}
