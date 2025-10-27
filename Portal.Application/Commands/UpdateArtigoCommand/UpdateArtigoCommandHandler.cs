using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateArtigoCommand
{
    public class UpdateArtigoCommandHandler : IRequestHandler<UpdateArtigoCommand, ResultViewModel>
    {
        private readonly IArtigoRepository _artigoRepository;
        public UpdateArtigoCommandHandler(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateArtigoCommand request, CancellationToken cancellationToken)
        {
            var artigo = await _artigoRepository.GetByIdAsync(request.id);
            if (artigo == null)
            {
                return ResultViewModel.Error("Artigo não encontrado");
            }
            artigo.Update(request.titulo, request.descricao);
            await _artigoRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }   
    }
}
