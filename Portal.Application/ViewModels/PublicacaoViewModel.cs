using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class PublicacaoViewModel
    {
        public PublicacaoViewModel(string titulo, string descricao, string arquivopdf)
        {
            Titulo = titulo;
            Descricao = descricao;
            this.arquivopdf = arquivopdf;
        }

        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        //public string Tipo { get; set; } = string.Empty; // "Artigo" ou "Revista"
        public string arquivopdf { get; set; } = string.Empty;
    }
}
