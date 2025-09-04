using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class EventoViewModel
    {
        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public DateTime data { get; private set; }
        public string local { get; private set; }
        public string area { get; private set; }
        public List<Usuario> Palestrante { get; private set; }
    }
}
