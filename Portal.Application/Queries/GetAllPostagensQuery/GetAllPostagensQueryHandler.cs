using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllPostagensQuery
{
    public class GetAllPostagensQueryHandler : IRequestHandler<GetAllPostagensQuery, ResultViewModel<List<PostagemViewModel>>>
    {
        private readonly IPostagemRepository _postagemRepository;
        public GetAllPostagensQueryHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        public async Task<ResultViewModel<List<PostagemViewModel>>> Handle(GetAllPostagensQuery request, CancellationToken cancellationToken)
        {
            var postagens = await _postagemRepository.GetAllAsync();
            var postagemViewModel = postagens.Select(p => new PostagemViewModel(p.conteudo, p.comentarios, p.IsDeleted)).ToList();
            return ResultViewModel<List<PostagemViewModel>>.Success(postagemViewModel);
        }
    }
}
