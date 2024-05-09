using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {
        public RepositorioRevista repositorioRevista = null;
        public TelaRevista TelaRevista = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3,-20}",
                "Id", "Etiqueta", "Cor", "Dias emprestados" 
            );

            ArrayList caixasCadastradas = repositorio.SelecionarTodos();

            foreach (Caixa caixa in caixasCadastradas)
            {
                if (caixa == null)
                  continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3,-20} ",
                    caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestados
                );
                

            }

            //ArrayList revistasCadastradas = repositorioRevista.SelecionarTodos();

          //  Console.WriteLine("REVISTAS:");

          //  Console.WriteLine(
          //    "{0, -10} | {1, -20} | {2, -10}",
          //    "Id", "Titulo", "Caixa"
          //);

          //  foreach (Revista revista in revistasCadastradas)
          //  {
          //      if (revista == null)
          //          continue;

          //      Console.WriteLine(
          //          "{0, -10} | {1, -20} | {2, -10} ",
          //          revista.Id,revista.Titulo ,revista.Caixa
          //      );
          //  }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome da etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite quantos dias de empréstimo terá: ");
            int dias = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(etiqueta, cor, dias);

            return caixa;
        }

       
    }
}