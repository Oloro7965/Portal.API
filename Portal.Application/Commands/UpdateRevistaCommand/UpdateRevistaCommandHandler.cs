using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateRevistaCommand
{
    public class UpdateRevistaCommandHandler : IRequestHandler<UpdateRevistaCommand, ResultViewModel>
    {
        private readonly IRevistaRepository _revistaRepository;
        public UpdateRevistaCommandHandler(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateRevistaCommand request, CancellationToken cancellationToken)
        {
            var revista = await _revistaRepository.GetByIdAsync(request.Id);
            if (revista == null)
            {
                return ResultViewModel.Error("Revista não encontrada.");
            }
            revista.Update(request.Titulo, request.Descricao, request.Edicao, request.Capa, request.Publicacao, request.Autores, request.Area);
            await _revistaRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
