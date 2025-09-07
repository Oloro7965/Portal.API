using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateArtigoCommand
{
    public class CreateArtigoCommandHandler : IRequestHandler<CreateArtigoCommand, ResultViewModel<object>>
    {
        public async Task<ResultViewModel<object>> Handle(CreateArtigoCommand request, CancellationToken cancellationToken)
        {
            var artigo = new artigo(
                request.Titulo,
                request.Descricao,
                request.DataPublicacao,
                request.ArquivoPdf,
                new List<Usuario>(),
                request.area,
                new List<Keywords>()
            );

            return await Task.FromResult(new ResultViewModel<object>(artigo));
        }

    }
}
