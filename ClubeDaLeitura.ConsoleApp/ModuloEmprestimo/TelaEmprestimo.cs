﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
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
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;

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
                "Id", "Data de Empréstimo", "Data de Devolução", "Amigo" //"Revista" 
            );

            ArrayList emprestimosCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimosCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                    emprestimo.Id, emprestimo.DataEmprestimo.ToShortDateString(),
                    emprestimo.DataDevolucao.ToShortDateString(), emprestimo.Amigo.Nome
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o ID do Amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            Emprestimo emprestimo = new Emprestimo(amigo);

            return emprestimo;


        }
    }
}

