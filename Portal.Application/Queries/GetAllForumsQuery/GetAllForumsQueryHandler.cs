using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllForumsQuery
{
    public class GetAllForumsQueryHandler : IRequestHandler<GetAllForumsQuery, ResultViewModel<List<ForumViewModel>>>
    {
        private readonly IForumRepository _forumRepository;
        public GetAllForumsQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<ResultViewModel<List<ForumViewModel>>> Handle(GetAllForumsQuery request, CancellationToken cancellationToken)
        {
            var forums = await _forumRepository.GetAllAsync();
            var forumViewModel = forums.Select(f => new ForumViewModel(f.titulo, f.area, f.descricao, f.postagem, f.IsDeleted)).ToList();
            return ResultViewModel<List<ForumViewModel>>.Success(forumViewModel);
        }
    }
}
