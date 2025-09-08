using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class ForumViewModel
    {
        public ForumViewModel(string titulo, Earea area, string descricao, List<postagem> postagem)
        {
            this.titulo = titulo;
            this.area = area;
            this.descricao = descricao;
            Postagem = postagem;
        }

        public string titulo { get; private set; }
        public Earea area { get; private set; }
        public string descricao { get; private set; }
        public List<Postagem> Postagem { get; private set; }
    }
}
