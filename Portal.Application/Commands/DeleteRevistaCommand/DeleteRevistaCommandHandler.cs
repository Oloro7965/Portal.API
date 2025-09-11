using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteRevistaCommand
{
    public class DeleteRevistaCommandHandler : IRequestHandler<DeleteRevistaCommand, ResultViewModel>
    {
        private readonly IRevistaRepository _revistaRepository;
        public DeleteRevistaCommandHandler(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteRevistaCommand request, CancellationToken cancellationToken)
        {
            var revista = await _revistaRepository.GetByIdAsync(request.Id);
            if (revista == null)
            {
                return ResultViewModel.Error("Revista não encontrada.");
            }
            revista.Delete();
            await _revistaRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
