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
        
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Devolver {tipoEntidade}");
            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Empréstimos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -3} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5,-8} | {6,-4}",
                "Id", "Data de Empréstimo", "Prazo de Devolução", "Amigo","Revista","Multa","Emprestado" 
            );

            ArrayList emprestimosCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimosCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -3} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5,-8} | {6,-4}",
                    emprestimo.Id, emprestimo.DataEmprestimo.ToShortDateString(),
                    emprestimo.DataDevolucao.ToShortDateString(), emprestimo.Amigo.Nome,emprestimo.Revista.Titulo,emprestimo.Multa,emprestimo.Emprestado
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
            string emprestado = "SIM";
           
            Emprestimo emprestimo = new Emprestimo(amigoSelecionado,dateTime,dataDevolucao,multa,revista,emprestado);

            return emprestimo;


        }

        public  EntidadeBase Devolver()
        {
            bool multa = false;
            string emprestado = "SIM";

            
            

            
            Console.WriteLine(
                "{0, -3} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5,-8} | {6,-4}",
                "Id", "Data de Empréstimo", "Prazo de Devolução", "Amigo", "Revista", "Multa", "Emprestado"
            );

            ArrayList emprestimosCadastradas = repositorio.SelecionarTodos();
            
            foreach (Emprestimo Emprestimo in emprestimosCadastradas)
            {
                if (Emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -3} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5,-8} | {6,-4}",
                    Emprestimo.Id, Emprestimo.DataEmprestimo.ToShortDateString(),
                    Emprestimo.DataDevolucao.ToShortDateString(), Emprestimo.Amigo.Nome, Emprestimo.Revista.Titulo, Emprestimo.Multa, Emprestimo.Emprestado
                );
            }

            Console.WriteLine("Digite o ID do Emprestimo: ");
            int idEmprestimo = int.Parse(Console.ReadLine());
            Emprestimo emprestimoSelecionado = (Emprestimo)repositorio.SelecionarPorId(idEmprestimo);

            if (emprestimoSelecionado.DataDevolucao < DateTime.Now)
            {
                 multa = true;
                 emprestado = "NÃO";
            }
            

            Emprestimo emprestimoCadastrados = new Emprestimo(emprestimoSelecionado.Amigo, emprestimoSelecionado.DataEmprestimo, emprestimoSelecionado.DataDevolucao, multa, emprestimoSelecionado.Revista,emprestado);

            return emprestimoCadastrados;


        }


    }
}

