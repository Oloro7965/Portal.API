using MediatR;
using Microsoft.AspNetCore.Http;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateArtigoCommand
{
    public class CreateArtigoCommand : IRequest<ResultViewModel<object>>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Earea area{ get; set; }
        //public string ArquivoPdf { get; set; }
        public DateTime DataPublicacao { get; set; }
        //public List<Keywords>? Keywords { get; set; }
        //public List<int>? KeywordsIds { get; set; }
        public List<string>? KeywordsNames { get; set; }
        public List<string>? Autores { get; set; }
        public IFormFile? Arquivopdf { get; set; }

    }
}
