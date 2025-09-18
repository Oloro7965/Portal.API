using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetEventoQuery
{
    public class GetEventoQueryHandler : IRequestHandler<GetEventoQuery, ResultViewModel<EventoViewModel>>
    {
        private readonly IEventRepository _eventRepository;
        public GetEventoQueryHandler(IEventRepository eventRepository) 
        {
            _eventRepository = eventRepository;
        }
        public async Task<ResultViewModel<EventoViewModel>> Handle(GetEventoQuery request, CancellationToken cancellationToken)
        {
            var evento = await _eventRepository.GetByIdAsync(request.Id);
            if (evento is null)
            {
                return ResultViewModel<EventoViewModel>.Error("Evento não encontrado.");
            }
            var EventoDetailViewModel = new EventoViewModel(evento.titulo, evento.descricao, evento.data,
                evento.local, evento.area, evento.Palestrante, evento.IsDeleted);

            return ResultViewModel<EventoViewModel>.Success(EventoDetailViewModel);
        }
    }
}
