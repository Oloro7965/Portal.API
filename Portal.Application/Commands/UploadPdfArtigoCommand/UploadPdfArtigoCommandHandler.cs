using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Core.Repositories;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UploadPdfArtigoCommand
{
    public class UploadPdfArtigoCommandHandler : IRequestHandler<UploadPdfArtigoCommand>
    {
        private readonly IArquivoArtigoService _arquivoService;

        public UploadPdfArtigoCommandHandler(IArquivoArtigoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        public async Task Handle(UploadPdfArtigoCommand request, CancellationToken cancellationToken)
        {
            if (request.ArquivoPdf == null || request.ArquivoPdf.Length == 0)
                throw new ArgumentException("Arquivo inválido");

            await _arquivoService.UploadAsync(request.ArquivoId, request.ArquivoPdf);

            
        }
    }
}
