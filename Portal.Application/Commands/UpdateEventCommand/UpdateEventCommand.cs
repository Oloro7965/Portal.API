using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateEventCommand
{
    public class UpdateEventCommand : IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public Earea Area { get; set; }
        public List<Usuario> Palestrantes { get; set; }
    }
}
