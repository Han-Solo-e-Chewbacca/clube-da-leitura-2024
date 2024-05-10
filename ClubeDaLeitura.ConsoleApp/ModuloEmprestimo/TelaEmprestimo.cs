using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;
        
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;

        public TelaCaixa telaCaixa = null;
        public RepositorioCaixa repositorioCaixa = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Empréstimos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                "Id", "Data de Empréstimo", "Prazo de Devolução", "Amigo","Revista" 
            );

            ArrayList emprestimosCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimosCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                    emprestimo.Id, emprestimo.DataEmprestimo.ToShortDateString(),
                    emprestimo.DataDevolucao.ToShortDateString(), emprestimo.Amigo.Nome,emprestimo.Revista.Titulo
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            

            telaAmigo.VisualizarRegistros(false);

            Console.WriteLine("Digite o ID do Amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            Console.WriteLine("Digite a data inicial do empréstimo(DD/MM/AAAA): ");
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());

            telaRevista.VisualizarRegistros(false);
            Console.Write("Informe o ID da revista que vai ser emprestada: ");
            int idRevista = int.Parse(Console.ReadLine());
           
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(idRevista);
            
            Caixa caixa = (Caixa)repositorioCaixa.SelecionarPorId(revista.Caixa.Id);
            
            DateTime dataDevolucao = dateTime.AddDays(Convert.ToInt32(caixa.DiasEmprestados));
            bool multa = false;

            Emprestimo emprestimo = new Emprestimo(amigoSelecionado,dateTime,dataDevolucao,multa,revista);

            return emprestimo;


        }
    }
}

