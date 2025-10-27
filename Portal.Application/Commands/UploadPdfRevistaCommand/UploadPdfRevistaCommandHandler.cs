using MediatR;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UploadPdfRevistaCommand
{
    public class UploadPdfRevistaCommandHandler : IRequestHandler<UploadPdfRevistaCommand>
    {
        private readonly IArquivoRevistaService _revistaService;

        public UploadPdfRevistaCommandHandler(IArquivoRevistaService revistaService)
        {
            _revistaService = revistaService;
        }

        public async Task Handle(UploadPdfRevistaCommand request, CancellationToken cancellationToken)
        {
            if (request.ArquivoPdf == null || request.ArquivoPdf.Length == 0)
                throw new ArgumentException("Arquivo inválido");

            await _revistaService.UploadAsync(request.ArquivoId, request.ArquivoPdf);
        }
    }
}
