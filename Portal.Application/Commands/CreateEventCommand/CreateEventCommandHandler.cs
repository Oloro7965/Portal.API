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
            var event = new Event(Request.Titulo, Request.Descricao, Request.Data, Request.Local, Request.Area, Request.PalestranteIds);
            await _eventRepository.AddAsync(event);
            return new ResultViewModel<object>(event);
        }
}
