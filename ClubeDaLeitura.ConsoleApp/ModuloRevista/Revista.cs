using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int Ano { get; set; }
        public Caixa Caixa { get; set; }

        public Revista(string titulo, int edicao, int ano, Caixa caixa)
        {
            Titulo = titulo;
            Edicao = edicao;
            Ano = ano;
            Caixa = caixa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"título\" é obrigatório");

            if (Edicao < 0)
                erros.Add("O campo \"edição\" é obrigatório");

            if (Ano < 0)
                erros.Add("O campo \"ano de publicação\" é obrigatório");

            if (Caixa == null)
                erros.Add("A caixa nescessita ser informada");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista revista = (Revista)novoRegistro;

            this.Titulo = revista.Titulo;
            this.Edicao = revista.Edicao;
            this.Ano = revista.Ano;
            this.Caixa = revista.Caixa;
        }
    }
}
