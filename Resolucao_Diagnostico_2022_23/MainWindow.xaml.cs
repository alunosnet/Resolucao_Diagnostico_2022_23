using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Resolucao_Diagnostico_2022_23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Aluno> Alunos=new List<Aluno>();
        List<Movimento> Movimentos = new List<Movimento>();

        public MainWindow()
        {
            InitializeComponent();
            CriarAlunosProfissional();
            CriarAlunosRegular();
        }

        private void CriarAlunosRegular()
        {
            Alunos.Add(new Regular
            {
                Nprocesso = 12345,
                Nome = "Aluno1",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Turma = "A",
                AnoEscolar = 10
            });
            Alunos.Add(new Regular
            {
                Nprocesso = 12346,
                Nome = "Aluno2",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Turma = "A",
                AnoEscolar = 10
            });
            Alunos.Add(new Regular
            {
                Nprocesso = 12347,
                Nome = "Aluno3",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Turma = "A",
                AnoEscolar = 10
            });
        }

        private void CriarAlunosProfissional()
        {
            Alunos.Add(new Profissional
            {
                Nprocesso = 12348,
                Nome = "Aluno4",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Curso="GPSI",
                Nif="123456789"
            });
            Alunos.Add(new Profissional
            {
                Nprocesso = 12349,
                Nome = "Aluno5",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Curso = "GPSI",
                Nif = "123456789"
            });
            Alunos.Add(new Profissional
            {
                Nprocesso = 12350,
                Nome = "Aluno6",
                DataNascimento = DateTime.Now.Date.AddMonths(-120),
                Estado = false,
                Curso = "GPSI",
                Nif = "123456789"
            });
        }

        private void btProcessaMovimento_Click(object sender, RoutedEventArgs e)
        {
            //Validar o nº processo
            int nprocesso;

            //verificar se é um número
            if(int.TryParse(tbNProcesso.Text,out nprocesso)==false)
            {
                lbMensagem.Content = "Nº de processo não é válido";
                return;
            }
            //verificar se existe na lista de alunos
            var aluno = Alunos.FirstOrDefault(a => a.Nprocesso == nprocesso);
            if(aluno==null)
            {
                lbMensagem.Content = "Nº de processo não foi encontrado";
                return;
            }
            //Mostrar fotografia
            string ficheiro = System.AppDomain.CurrentDomain.BaseDirectory + "Fotos\\" + nprocesso + ".jpg";
            if(File.Exists(ficheiro))
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                img.UriSource = new Uri(ficheiro);
                img.EndInit();
                imgFoto.Source = img;
            }
            //Indicar tipo de movimento
            string tipoMovimento = "";
            if (aluno.Estado == false)
                tipoMovimento = "Entrada";
            else
                tipoMovimento = "Saída";
            lbMensagem.Content = $"{aluno.Nome} - {tipoMovimento}";
            //Registar o movimento
            Movimentos.Add(new Movimento(aluno,DateTime.Now,tipoMovimento));
            //Atualizar o estado do aluno
            aluno.Estado = !aluno.Estado;
        }

        private void btListaMovimentos_Click(object sender, RoutedEventArgs e)
        {
            AreaAdmin areaAdmin = new AreaAdmin(Movimentos);
            areaAdmin.Show();
        }
    }
}
