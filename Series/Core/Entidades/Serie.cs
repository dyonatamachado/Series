using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Core.Entidades
{
    public class Serie : EntidadeBase
    {
        public Serie(int ano, string titulo, string descricao, Genero genero) : base()
        {
            Ano = ano;
            Titulo = titulo;
            Descricao = descricao;
            Genero = genero;
        }

        public int Ano { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Genero Genero { get; private set; }

        public void Atualizar(int ano, string titulo, string descricao, Genero genero)
        {
            Ano = ano;
            Titulo = titulo;
            Descricao = descricao;
            Genero = genero;
        }
    }
}
