using MediatR;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UploadImagemCommand
{
    public class UploadImagemCommandHandler : IRequestHandler<UploadImagemCommand>
    {
        private readonly IArquivoRevistaService _revistaService;

        public UploadImagemCommandHandler(IArquivoRevistaService revistaService)
        {
            _revistaService = revistaService;
        }

        public async Task Handle(UploadImagemCommand request, CancellationToken cancellationToken)
        {
            if (request.Capa == null || request.Capa.Length == 0)
                throw new ArgumentException("Arquivo inválido");

            await _revistaService.UploadImagemAsync(request.Id, request.Capa);
        }
    }
}
