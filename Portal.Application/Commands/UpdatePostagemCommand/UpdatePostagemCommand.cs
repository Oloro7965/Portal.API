using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdatePostagemCommand
{
    public class UpdatePostagemCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
