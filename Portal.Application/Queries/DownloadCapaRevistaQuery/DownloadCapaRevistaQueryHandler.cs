using MediatR;
using Portal.Application.Queries.BaixarRevistaQuery;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.DownloadCapaRevistaQuery
{
    public class DownloadCapaRevistaQueryHandler : IRequestHandler<DownloadCapaRevistaQuery, byte[]>
    {
        private readonly IArquivoRevistaService _revistaService;

        public DownloadCapaRevistaQueryHandler(IArquivoRevistaService revistaService)
        {
            _revistaService = revistaService;
        }

        public async Task<byte[]> Handle(DownloadCapaRevistaQuery request, CancellationToken cancellationToken)
        {
            var bytes = await _revistaService.BaixarImagemAsync(request.Id);

            if (bytes == null || bytes.Length == 0)
                throw new Exception("Arquivo não encontrado");

            return bytes;
        }
    }
}
