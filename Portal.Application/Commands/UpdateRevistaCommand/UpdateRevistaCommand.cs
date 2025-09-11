using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateRevistaCommand
{
    public class UpdateRevistaCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Edicao { get; set; }
        public string Capa { get; set; }
        public DateTime Publicacao { get; set; }
        public string Arquivopdf { get; set; }
        public List<Usuario> Autores { get; set; }
        public Earea Area { get; set; }
    }
}
