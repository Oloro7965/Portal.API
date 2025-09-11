using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateForumCommand
{
    public class UpdateForumCommandHandler : IRequestHandler<UpdateForumCommand, ResultViewModel>
    {
        private readonly IForumRepository _forumRepository;
        public UpdateForumCommandHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateForumCommand request, CancellationToken cancellationToken)
        {
            var forum = await _forumRepository.GetByIdAsync(request.Id);
            if (forum == null)
            {
                return ResultViewModel.Error("Fórum não encontrado.");
            }
            forum.Update(request.Titulo, request.Area, request.Descricao, request.Postagem);
            await _forumRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
