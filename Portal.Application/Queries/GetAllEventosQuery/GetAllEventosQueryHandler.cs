using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllEventosQuery
{
    public class GetAllEventosQueryHandler : IRequestHandler<GetAllEventosQuery, ResultViewModel<List<EventoViewModel>>>
    {
        private readonly IEventRepository _eventRepository;
        public GetAllEventosQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        public async Task<ResultViewModel<List<EventoViewModel>>> Handle(GetAllEventosQuery request, CancellationToken cancellationToken)
        {
            var eventos = await _eventRepository.GetAllAsync();
            var eventoViewModel = eventos.Select(e => new EventoViewModel(e.titulo, e.descricao, e.data, e.local, e.area, e.Palestrante ,e.IsDeleted)).ToList();
            return ResultViewModel<List<EventoViewModel>>.Success(eventoViewModel);
        }
    }
}
