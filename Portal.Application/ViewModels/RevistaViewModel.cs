using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class RevistaViewModel
    {
        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public string edicao { get; private set; }
        public string capa { get; private set; }
        public DateTime publicacao { get; private set; }
        public string arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords { get; private set; }
    }
}
