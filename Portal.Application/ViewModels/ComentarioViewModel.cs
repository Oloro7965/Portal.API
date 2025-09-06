using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class ComentarioViewModel
    {
        public ComentarioViewModel(string conteudo)
        {
            this.conteudo = conteudo;
        }

        public string conteudo { get; private set; }
    }
}
