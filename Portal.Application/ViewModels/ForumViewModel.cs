using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class ForumViewModel
    {
        public string titulo { get; private set; }
        public Earea area { get; private set; }
        public string descricao { get; private set; }
        public List<postagem> Postagem { get; private set; }
    }
}
