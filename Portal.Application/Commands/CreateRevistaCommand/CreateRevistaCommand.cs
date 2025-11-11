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

namespace Portal.Application.Commands.CreateRevistaCommand
{
    public class CreateRevistaCommand : IRequest<ResultViewModel<object>>
    {
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime publicacao { get; set; }
        //public string arquivopdf { get; set; }
        public Earea area { get; set; }
        public IFormFile Capa { get; set; }
        public IFormFile Arquivopdf {  get; set; }
        public List<string>? Autores { get; set; }
        public List<string>? KeywordsNames { get; set; }
        //public List<int>? KeywordsIds{ get; set; }
    }
}
