using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteComentarioCommand
{
    public class DeleteComentarioCommand:IRequest<ResultViewModel>
    {
        public DeleteComentarioCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
