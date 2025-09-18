using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class PostagemViewModel
    {
        public PostagemViewModel(string conteudo, List<Comentario> comentarios, bool isDeleted)
        {
            this.conteudo = conteudo;
            this.comentarios = comentarios;
            IsDeleted = isDeleted;

        }

        public string conteudo { get; private set; }
        public List<Comentario> comentarios { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
