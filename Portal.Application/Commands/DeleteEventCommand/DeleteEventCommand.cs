using Portal.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteEventCommand
{
    public class DeleteEventCommand:IRequest<ResultViewModel>
    {
        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }    
    }
}
