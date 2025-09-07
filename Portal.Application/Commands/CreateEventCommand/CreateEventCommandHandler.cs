using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateEventCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ResultViewModel<object>>
    {
        public async Task<ResultViewModel<object>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return new ResultViewModel<object>
            {
                Success = true,
                Message = "Evento criado com sucesso!",
             
            };
        }
}
