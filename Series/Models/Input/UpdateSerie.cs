using Series.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Models.Input
{
    public class UpdateSerie
    {
        public int Ano { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Genero Genero { get; set; }
    }
}
