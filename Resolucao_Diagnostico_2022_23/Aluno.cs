using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolucao_Diagnostico_2022_23
{
    public class Aluno
    {
        public int Nprocesso { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Estado { get; set; } /*True - na escola; False - fora da escola*/

        public override string ToString()
        {
            return Nome;
        }
    }
}
