using MediatR;
using Portal.Core.Entities; 
using Portal.Core.Repositories; 
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Portal.Application.Commands.CreateEventCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ResultViewModel<object>>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var evento = new Evento(request.Titulo, request.Descricao, request.Data, request.Local, request.Area, request.PalestranteIds);
            await _eventRepository.AddAsync(evento);
            return new ResultViewModel<object>(evento);
        }
    }
}
