using Series.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Models.View
{
    public class ViewSerie
    {
        public ViewSerie(int ano, string titulo, string descricao, Genero genero, int id)
        {
            Ano = ano;
            Titulo = titulo;
            Descricao = descricao;
            Genero = genero;
            Id = id;
        }

        public int Ano { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Genero Genero { get; private set; }
        public int Id { get; private set; }
    }
}
