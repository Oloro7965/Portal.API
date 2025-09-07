using MediatR;
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
        public string edicao { get; set; }
        public string capa { get; set; }
        public DateTime publicacao { get; set; }
        public string arquivopdf { get; set; }
        public List<Usuario> autores { get; set; }
        public Earea area { get; set; }
        public List<Keywords> keywords { get; set; }
    }
}
