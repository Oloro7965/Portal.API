using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeletePostagemCommand
{
    public class DeletePostagemCommand:IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public DeletePostagemCommand(Guid id)
        {
            Id = id;
        }
    }
    
}

