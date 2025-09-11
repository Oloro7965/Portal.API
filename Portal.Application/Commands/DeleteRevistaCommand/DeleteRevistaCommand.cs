using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteRevistaCommand
{
    public class DeleteRevistaCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public DeleteRevistaCommand(Guid id)
        {
            Id = id;
        }
    }
}
