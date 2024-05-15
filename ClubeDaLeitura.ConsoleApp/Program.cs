using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
                               
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            
            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

          

            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            


            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista();

            telaRevista.tipoEntidade = "Revista";           
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.repositorio = repositorioRevista;
            telaRevista.telaCaixa=telaCaixa;
            //telaCaixa.repositorioRevista = repositorioRevista;

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio=repositorioEmprestimo;
            telaEmprestimo.repositorioAmigo = repositorioAmigo ;
            telaEmprestimo.telaAmigo = telaAmigo ;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.telaCaixa = telaCaixa ;
            telaEmprestimo.repositorioCaixa=repositorioCaixa ;

            RepositorioReserva repositorioReserva = new RepositorioReserva();

            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.telaRevista = telaRevista;
            telaReserva.repositorioRevista = repositorioRevista ;
            telaReserva.repositorioAmigo= repositorioAmigo ;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.repositorio=repositorioReserva;
            




            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaAmigo;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRevista;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaEmprestimo;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaReserva;
           

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
                if (opcaoPrincipalEscolhida == '4')
                {
                    if (operacaoEscolhida == '5')
                        telaEmprestimo.Devolver();
                    else if (operacaoEscolhida == '6') { telaEmprestimo.PagarMulta(); }
                }

            }
        }
    }
}
