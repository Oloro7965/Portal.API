using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;

namespace Portal.Application.Commands.UpdateEventCommand
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ResultViewModel>
    {
        private readonly IEventRepository _eventRepository;
        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var evento = await _eventRepository.GetByIdAsync(request.id);
            if (evento == null)
            {
                return ResultViewModel.Error("Evento não encontrado.");
            }
            evento.Update(request.Titulo, request.Descricao, request.Data, request.Local, request.Area, request.Palestrantes);
            await _eventRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
