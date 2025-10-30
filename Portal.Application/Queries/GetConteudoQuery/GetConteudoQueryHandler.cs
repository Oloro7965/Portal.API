using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Portal.Application.Interfaces;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetConteudoQuery
{
    public class GetConteudoQueryHandler : IRequestHandler<GetConteudoQuery, ResultViewModel<List<PublicacaoViewModel>>>
    {
        private readonly IArtigoRepository _artigoRepository;
        private readonly IRevistaRepository _revistaRepository;
        private readonly IKeywordService _keywordService;
        private readonly IUrlGenerator _urlGenerator;

        public GetConteudoQueryHandler(IArtigoRepository artigoRepository, IRevistaRepository revistaRepository,
            IKeywordService keywordService, IUrlGenerator urlGenerator)
        {
            _artigoRepository = artigoRepository;
            _revistaRepository = revistaRepository;
            _keywordService = keywordService;
            _urlGenerator = urlGenerator;
        }

        public async Task<ResultViewModel<List<PublicacaoViewModel>>> Handle(GetConteudoQuery request, CancellationToken cancellationToken)
        {
            var keywords = await _keywordService.ExtractKeywordsAsync(request.Input);

            var artigos = await _artigoRepository.SearchByKeywordsAsync(keywords);
            var revistas = await _revistaRepository.SearchByKeywordsAsync(keywords);

            var resultado = artigos.Select(a => new PublicacaoViewModel(a.titulo,a.descricao, _urlGenerator.GetDownloadArtigoUrl(a.Id)))
                            .Concat(revistas.Select(r => new PublicacaoViewModel(r.titulo, r.descricao, _urlGenerator.GetDownloadRevistaUrl(r.Id))))
                            .ToList();

            return ResultViewModel<List<PublicacaoViewModel>>.Success(resultado,extra: keywords);
        }
    }
}
