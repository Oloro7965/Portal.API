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

namespace Portal.Application.Queries.GetAllRevistasQuery
{
    public class GetAllRevistasQueryHandler : IRequestHandler<GetAllRevistasQuery, ResultViewModel<List<RevistaViewModel>>>
    {
        private readonly IRevistaRepository _revistaRepository;
        private readonly IUrlGenerator _urlGenerator;

        public GetAllRevistasQueryHandler(IRevistaRepository revistaRepository, IUrlGenerator urlGenerator)
        {
            _revistaRepository = revistaRepository;
            _urlGenerator = urlGenerator;
        }

        public async Task<ResultViewModel<List<RevistaViewModel>>> Handle(GetAllRevistasQuery request, CancellationToken cancellationToken)
        {
            var revistas = await _revistaRepository.GetAllAsync();
            var revistaViewModel = revistas.Select(r => new RevistaViewModel(r.titulo, r.descricao,r.publicacao,
                (r.autores ?? new List<Usuario>()).Select(u => new UsuarioViewModel(u.NomeCompleto, u.email)).ToList(), 
                r.area.ToString(), (r.keywords ?? new List<Keywords>()).Select(u => new KeywordsViewModel(u.titulo)).ToList(),
                r.IsDeleted, r.capa != null ? _urlGenerator.GetImagemRevistaUrl(r.Id) : null,
                r.arquivopdf != null ? _urlGenerator.GetDownloadRevistaUrl(r.Id) : null)).ToList();
            return ResultViewModel<List<RevistaViewModel>>.Success(revistaViewModel);
        }
    }
}
