using MediatR;
using Portal.Core.Entities;
using Portal.Core.Enums;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateForumCommand
{
    public class UpdateForumCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Earea Area { get; set; }
        public string Descricao { get; set; }
        public List<Postagem> Postagem { get; set; }
    }
}
