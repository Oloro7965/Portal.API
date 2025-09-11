using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteForumCommand
{
    public class DeleteForumCommandHandler : IRequestHandler<DeleteForumCommand, ResultViewModel>
    {
        private readonly IForumRepository _forumRepository;
        public DeleteForumCommandHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteForumCommand request, CancellationToken cancellationToken)
        {
            var forum = await _forumRepository.GetByIdAsync(request.Id);
            if (forum == null)
            {
                return ResultViewModel.Error("Nenhum fórum encontrado.");
            }
            forum.Delete();
            await _forumRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
