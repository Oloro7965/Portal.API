using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllComentariosQuery
{
    public class GetAllComentariosQueryHandler : IRequestHandler< GetAllComentariosQuery, ResultViewModel<List<ComentarioViewModel>>>
    {
        private readonly IComentarioRepository _comentarioRepository;

        public GetAllComentariosQueryHandler(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<ResultViewModel<List<ComentarioViewModel>>> Handle(GetAllComentariosQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _comentarioRepository.GetAllAsync();

            var comentarioViewModel = comentarios.Select(b => new ComentarioViewModel(b.conteudo, b.IsDeleted))
                .ToList();

            return ResultViewModel<List<ComentarioViewModel>>.Success(comentarioViewModel);
        }
    }
}
