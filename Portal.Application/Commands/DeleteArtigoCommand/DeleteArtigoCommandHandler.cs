using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteArtigoCommand
{
    public class DeleteArtigoCommandHandler : ResultViewModel, IRequestHandler<DeleteArtigoCommand, ResultViewModel>
    {
        private readonly IArtigoRepository _artigoRepository;
        public DeleteArtigoCommandHandler(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteArtigoCommand request, CancellationToken cancellationToken)
        {
            var artigo = await _artigoRepository.GetByIdAsync(request.Id);
            if (artigo == null)
            {
                return ResultViewModel.Error("Nenhum artigo encontrado.");
            }
            artigo.Delete();
            await _artigoRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }

    }
}
