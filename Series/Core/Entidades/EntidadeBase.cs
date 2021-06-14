using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Core.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            Ativo = true;
        }
        public int Id { get; private set; }
        public bool Ativo { get; private set; }

        public void Desativar()
        {
            Ativo = false;
        }
    }


}
