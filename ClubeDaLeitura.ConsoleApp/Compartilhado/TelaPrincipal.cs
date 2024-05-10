using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal static class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube Do Livro             |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Digite qual categoria você deseja acessar:\n");
            Console.WriteLine("1 - Amigos ");
            Console.WriteLine("2 - Caixas ");
            Console.WriteLine("3 - Revistas ");
            Console.WriteLine("4 - Emprestimo ");
            Console.WriteLine("5 - Reserva ");
            

            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}
