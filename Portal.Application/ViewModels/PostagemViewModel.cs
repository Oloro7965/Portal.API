using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class PostagemViewModel
    {
        public PostagemViewModel(string conteudo, List<comentario> comentarios)
        {
            this.conteudo = conteudo;
            this.comentarios = comentarios;
        }

        public string conteudo { get; private set; }
        public List<comentario> comentarios { get; private set; }
    }
}
