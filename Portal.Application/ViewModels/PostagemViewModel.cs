using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class PostagemViewModel
    {
        public string conteudo { get; private set; }
        public List<comentario> comentarios { get; private set; }
    }
}
