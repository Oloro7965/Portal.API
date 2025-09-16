using MediatR;
using Portal.Application.ViewModels;
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
        
        public GetAllArtigosQueryHandler(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        public async Task<ResultViewModel<List<ArtigoViewModel>>> Handle(GetAllArtigosQuery request, CancellationToken cancellationToken)
        {
            var artigos = await _artigoRepository.GetAllAsync();
            var artigoViewModel = artigos.Select(b => new ArtigoViewModel(b.titulo, b.descricao, b.publicacao, b.arquivopdf, b.autores, b.area, b.keywords)).ToList();
            
            return ResultViewModel<List<ArtigoViewModel>>.Success(artigoViewModel);
        }
    } 
}
