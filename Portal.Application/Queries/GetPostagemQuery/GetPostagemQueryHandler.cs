using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetPostagemQuery
{
    public class GetPostagemQueryHandler :IRequestHandler<GetPostagemQuery, ResultViewModel<PostagemViewModel>>
    {
        private readonly IPostagemRepository _postagemRepository;
        public GetPostagemQueryHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        public async Task<ResultViewModel<PostagemViewModel>> Handle(GetPostagemQuery request, CancellationToken cancellationToken)
        {
            var postagem = await _postagemRepository.GetByIdAsync(request.Id);
            if (postagem is null)
            {
                return ResultViewModel<PostagemViewModel>.Error("Postagem não encontrada.");
            }
            var PostagemDetailViewModel = new PostagemViewModel(postagem.conteudo, postagem.comentarios, postagem.IsDeleted);
            return ResultViewModel<PostagemViewModel>.Success(PostagemDetailViewModel);
        }
    }
}
