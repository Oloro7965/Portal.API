using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteForumCommand
{
    public class DeleteForumCommand:IRequest<ResultViewModel>
    {
        public DeleteForumCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}

