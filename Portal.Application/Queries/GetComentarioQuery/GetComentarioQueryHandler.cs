using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetComentarioQuery
{
    public class GetComentarioQueryHandler : IRequestHandler<GetComentarioQuery, ResultViewModel<ComentarioViewModel>>
    {
        private readonly IComentarioRepository _comentarioRepository;
        public GetComentarioQueryHandler(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }
        public async Task<ResultViewModel<ComentarioViewModel>> Handle(GetComentarioQuery request, CancellationToken cancellationToken)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(request.Id);
            if (comentario is null)
            {
                return ResultViewModel<ComentarioViewModel>.Error("Comentário não encontrado.");
            }
            var ComentarioDetailViewModel = new ComentarioViewModel(comentario.conteudo, comentario.IsDeleted);
            return ResultViewModel<ComentarioViewModel>.Success(ComentarioDetailViewModel);
        }
    }
}
