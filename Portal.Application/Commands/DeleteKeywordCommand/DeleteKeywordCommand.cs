using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteKeywordCommand
{
    public class DeleteKeywordCommand: IRequest<ResultViewModel>
    {
        public DeleteKeywordCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
