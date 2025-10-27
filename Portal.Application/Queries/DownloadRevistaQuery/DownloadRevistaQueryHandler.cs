using MediatR;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.BaixarRevistaQuery
{
    public class DownloadRevistaQueryHandler: IRequestHandler<DownloadRevistaQuery, byte[]>
    {
        private readonly IArquivoRevistaService _revistaService;

        public DownloadRevistaQueryHandler(IArquivoRevistaService revistaService)
        {
            _revistaService = revistaService;
        }

        public async Task<byte[]> Handle(DownloadRevistaQuery request, CancellationToken cancellationToken)
        {
            var bytes = await _revistaService.BaixarAsync(request.Id);

            if (bytes == null || bytes.Length == 0)
                throw new Exception("Arquivo não encontrado");

            return bytes;
        }
    }
}
