using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestados { get; set; }
        public object Revista { get; internal set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestados = diasEmprestimo;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"etiqueta\" é obrigatório");

            if (string.IsNullOrEmpty(Cor.Trim()))
                erros.Add("O campo \"cor\" é obrigatório");

            if (DiasEmprestados < 1)
                erros.Add("O campo \"dias de emprestimo\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Caixa caixa = (Caixa)novoRegistro;

            this.Etiqueta = caixa.Etiqueta;
            this.Cor = caixa.Cor;
            this.DiasEmprestados = caixa.DiasEmprestados;
            
        }
    }
}