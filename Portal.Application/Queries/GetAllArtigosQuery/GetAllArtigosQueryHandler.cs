using MediatR;
using Portal.Application.Interfaces;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllArtigosQuery
{
    public class GetAllArtigosQueryHandler : IRequestHandler<GetAllArtigosQuery, ResultViewModel<List<ArtigoViewModel>>>
    {
        private readonly IArtigoRepository _artigoRepository;
        private readonly IUrlGenerator _urlGenerator;

        public GetAllArtigosQueryHandler(IArtigoRepository artigoRepository, IUrlGenerator urlGenerator)
        {
            _artigoRepository = artigoRepository;
            _urlGenerator = urlGenerator;
        }

        public async Task<ResultViewModel<List<ArtigoViewModel>>> Handle(GetAllArtigosQuery request, CancellationToken cancellationToken)
        {
            var artigos = await _artigoRepository.GetAllAsync();
            var artigoViewModel = artigos.Select(b => new ArtigoViewModel(b.Id,b.titulo, b.descricao, 
                b.publicacao,(b.autores?? new List<Usuario>()).Select(u => new UsuarioViewModel(u.NomeCompleto,u.email)).ToList(), 
                b.area.ToString(), (b.keywords?? new List<Keywords>()).Select(u => new KeywordsViewModel(u.titulo)).ToList(),
                b.arquivopdf != null ? _urlGenerator.GetDownloadArtigoUrl(b.Id) : null)).ToList();
   
            return ResultViewModel<List<ArtigoViewModel>>.Success(artigoViewModel);
        }
    } 
}
