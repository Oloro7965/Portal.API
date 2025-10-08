using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetForumQuery
{
    public class GetForumQueryHandler : IRequestHandler<GetForumQuery, ResultViewModel<ForumViewModel>>
    {
        private readonly IForumRepository _forumRepository;
        public GetForumQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<ResultViewModel<ForumViewModel>> Handle(GetForumQuery request, CancellationToken cancellationToken)
        {
            var forum = await _forumRepository.GetByIdAsync(request.Id);
            if (forum == null)
            {
                return ResultViewModel<ForumViewModel>.Error("Fórum não encontrado.");
            }
            var ForumDetailViewModel = new ForumViewModel(forum.titulo, forum.area, forum.descricao, forum.postagens, forum.IsDeleted);
            return ResultViewModel<ForumViewModel>.Success(ForumDetailViewModel);
        }
    }
}
