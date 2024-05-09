using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public RepositorioAmigo repositorioAmigo = null;

        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;

        public RepositorioEmprestimo repositorioEmprestimo = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Reservas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20}",
                "Id", "Expirado", "Data da Reserva", "Data Limite", "Amigo", "Revista"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20}",
                    reserva.Id, reserva.Expirado ? "Sim" : "Não", reserva.DataReserva.ToShortDateString(),
                    reserva.DataLimite.ToShortDateString(), reserva.Amigo.Nome, reserva.Revista.Titulo
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);
            Console.Write("Informe o ID do amigo que vai fazer o emprestimo: ");
            int idAmigo = int.Parse(Console.ReadLine());
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);
            Console.Write("Informe o ID da revista que vai ser emprestada: ");
            int idRevista = int.Parse(Console.ReadLine());
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(idRevista);

            Reserva reserva = new Reserva(amigo, revista,DateTime.Now);

            return reserva;
        }

        
       

        //public override char ApresentarMenu()
        //{
        //    Console.Clear();

        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine($"        Gestão de {tipoEntidade}s       ");
        //    Console.WriteLine("----------------------------------------");

        //    Console.WriteLine();

        //    Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
        //    Console.WriteLine($"2 - Visualizar {tipoEntidade}s");
        //    Console.WriteLine($"3 - Realizar empréstimo da {tipoEntidade}s");

        //    Console.WriteLine("S - Voltar");

        //    Console.WriteLine();

        //    Console.Write("Escolha uma das opções: ");
        //    char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        //    return operacaoEscolhida;
        //}
        //private void BuscarReservas()
        //{
        //    Console.WriteLine("Visualizando Reservas em Aberto...");

        //    Console.WriteLine();

        //    Console.WriteLine(
        //        "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20}",
        //        "Id", "Data da Reserva", "Data Limite", "Amigo", "Revista"
        //    );

            
        //}
    }
}
