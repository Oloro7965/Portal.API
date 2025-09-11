using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteEventCommand
{
    public class DeleteEventCommandHandler : ResultViewModel, IRequestHandler<DeleteEventCommand, ResultViewModel>
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var evento = await _eventRepository.GetByIdAsync(request.Id);
            if (evento == null)
            {
                return ResultViewModel.Error("Nenhum evento encontrado.");
            }
            evento.Delete();
            await _eventRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
