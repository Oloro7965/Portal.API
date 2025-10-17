using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteKeywordCommand
{
    public class DeleteKeywordCommandHandler : IRequestHandler<DeleteKeywordCommand, ResultViewModel>
    {
        private readonly IKeywordsRepository _keywordsRepository;

        public DeleteKeywordCommandHandler(IKeywordsRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteKeywordCommand request, CancellationToken cancellationToken)
        {
            var keyword = await _keywordsRepository.GetByIdAsync(request.Id);
            if (keyword == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            keyword.Delete();
            await _keywordsRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
