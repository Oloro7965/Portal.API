using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portal.Core.Entities
{
    public class Evento:BaseEntity
    {
        public Evento(string titulo, string descricao, DateTime data, string local, string area, List<Usuario> palestrante)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.data = data;
            this.local = local;
            this.area = area;
            Palestrante = palestrante;
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public DateTime data { get; private set; }
        public string local { get; private set; }
        public string area { get; private set; }
        public List<Usuario> Palestrante { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
