using Portal.Core.Enums;
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
        public Evento(string titulo, string descricao, DateTime data, string local, Earea area)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.data = data;
            this.local = local;
            this.area = area;
            Palestrantes = new List<Usuario>();
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public DateTime data { get; private set; }
        public string local { get; private set; }
        public Earea area { get; private set; }
        public List<Usuario> Palestrantes { get; private set; }
        public string fotoevideos { get; set; } //fazer 
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Titulo, string Descricao, DateTime Data, string Local, Earea Area, List<Usuario> PalestranteIds)
        {
            titulo = Titulo;
            descricao = Descricao;
            data = Data;
            local = Local;
            area = Area;
            Palestrantes = PalestranteIds;
        }
    }
}
