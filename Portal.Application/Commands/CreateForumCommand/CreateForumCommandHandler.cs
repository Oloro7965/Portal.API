using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateForumCommand
{
    public class CreateForumCommandHandler : IRequestHandler<CreateForumCommand, ResultViewModel<object>>
    {
        private readonly IForumRepository _forumRepository;
        public CreateForumCommandHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<ResultViewModel<object>> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            var forum = new Forum(request.titulo, request.area, request.descricao /* request.Postagem*/);
            await _forumRepository.AddAsync(forum);
            return ResultViewModel<object>.Success(new { forum.Id });
        }
    }
}
