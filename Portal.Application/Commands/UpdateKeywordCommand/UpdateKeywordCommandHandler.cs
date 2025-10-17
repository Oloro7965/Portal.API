using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateKeywordCommand
{
    public class UpdateKeywordCommandHandler : IRequestHandler<UpdateKeywordCommand, ResultViewModel>
    {
        private readonly IKeywordsRepository _keywordsRepository;

        public UpdateKeywordCommandHandler(IKeywordsRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateKeywordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _keywordsRepository.GetByIdAsync(request.id);
            if (usuario == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            usuario.Update(request.NovoTitulo);
            await _keywordsRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
