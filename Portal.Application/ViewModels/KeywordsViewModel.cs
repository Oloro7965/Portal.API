using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    internal class KeywordsViewModel
    {
        public KeywordsViewModel(string titulo)
        {
            this.titulo = titulo;
        }

        public string titulo { get; private set; }
    }
}
