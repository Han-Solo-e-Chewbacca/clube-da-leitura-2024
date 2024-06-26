﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class RepositorioBase
    {
        protected List<EntidadeBase> registros = new List<EntidadeBase>();

        protected int contadorId = 1;

        public void Cadastrar(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = contadorId++;

            registros.Add(novoRegistro);
        }

        public bool Editar(int id, EntidadeBase novaEntidade)
        {
            novaEntidade.Id = id;

            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    entidade.AtualizarRegistro(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    registros.Remove(entidade);

                    return true;
                }
            }

            return false;
        }

        public List<EntidadeBase> SelecionarTodos()
        {
            return registros;
        }

        public EntidadeBase SelecionarPorId(int id)
        {
            foreach (EntidadeBase e in registros)
            {
                if (e == null)
                    continue;

                else if (e.Id == id)
                    return e;
            }

            return null;
        }

        public bool Existe(int id)
        {
            foreach (EntidadeBase e in registros)
            {
                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }
    }
}
