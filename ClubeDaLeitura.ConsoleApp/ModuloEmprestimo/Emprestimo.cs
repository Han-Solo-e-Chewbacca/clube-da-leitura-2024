﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
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
    internal class Emprestimo : EntidadeBase
    {
        public Amigo Amigo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Multa { get; set; }
        public Revista Revista { get; set; }
        public bool Emprestado { get; set; }


        public Emprestimo(Amigo amigo, DateTime dataEmprestimo, DateTime dataDevolucao,bool multa,Revista revista,bool emprestado)
        {
            Amigo = amigo;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Multa = multa;
            Revista = revista;
            Emprestado = emprestado;
        }

        public Emprestimo(Amigo amigo)
        {
            Amigo = amigo;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (Amigo == null)
                erros.Add("O campo \"Amigo\" é obrigatório");
          
            if (DataEmprestimo == null)
                erros.Add("O campo \"DataEmprestimo\" é obrigatório");

            if (DataDevolucao == null)
                erros.Add("O campo \"DataDevolucao\" é obrigatório");
           
            if (Revista == null)
                erros.Add("O campo \"Revista\" é obrigatório");


            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Emprestimo emprestimo = (Emprestimo)novoRegistro;

            this.Amigo = emprestimo.Amigo;            
            this.DataEmprestimo = emprestimo.DataEmprestimo;
            this.DataDevolucao = emprestimo.DataDevolucao;
            this.Multa = emprestimo.Multa;
            this.Revista = emprestimo.Revista;
            this.Emprestado = emprestimo.Emprestado;

        }
    }

    
}
