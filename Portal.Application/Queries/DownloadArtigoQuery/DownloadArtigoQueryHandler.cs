using MediatR;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.DownloadArtigoQuery
{
    public class DownloadArtigoQueryHandler : IRequestHandler<DownloadArtigoQuery, byte[]>
    {
        private readonly IArquivoArtigoService _artigoService;

        public DownloadArtigoQueryHandler(IArquivoArtigoService artigoService)
        {
            _artigoService = artigoService;
        }

        public async Task<byte[]> Handle(DownloadArtigoQuery request, CancellationToken cancellationToken)
        {
            var bytes = await _artigoService.BaixarAsync(request.Id);

            if (bytes == null || bytes.Length == 0)
                throw new Exception("Arquivo não encontrado");

            return bytes;
        }
    }
}
