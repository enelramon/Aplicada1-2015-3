using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolaMundo
{
   public  class Categorias
    {
        public int Id { get; set; }
        public string Descricion { get; set; }

        public Categorias()
        {
            this.Id = 0;
            this.Descricion = "";
        }

        public Categorias(int id, string descripcion)
        {
            this.Id = id;
            this.Descricion = descripcion;
        }
    }
}
