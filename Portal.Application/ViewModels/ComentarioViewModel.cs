using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class ComentarioViewModel
    {
        public ComentarioViewModel(string conteudo, bool isDeleted)
        {
            this.conteudo = conteudo;
            IsDeleted = isDeleted;
        }

        public string conteudo { get; private set; }
        public bool IsDeleted { get; private set; } 
    }
}
