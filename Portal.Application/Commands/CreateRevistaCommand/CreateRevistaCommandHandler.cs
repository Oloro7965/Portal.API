using MediatR;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Portal.Core.Service;

namespace Portal.Application.Commands.CreateRevistaCommand
{
    public class CreateRevistaCommandHandler : IRequestHandler<CreateRevistaCommand, ResultViewModel<object>>   
    {
        private readonly IRevistaRepository _revistaRepository;
        private readonly IKeywordsRepository _keywordsRepository;
        private readonly IArquivoRevistaService _arquivoRevistaService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateRevistaCommandHandler(IRevistaRepository revistaRepository, IKeywordsRepository keywordsRepository,
            IArquivoRevistaService arquivoRevistaService, IUsuarioRepository usuarioRepository)
        {
            _revistaRepository = revistaRepository;
            _keywordsRepository = keywordsRepository;
            _arquivoRevistaService = arquivoRevistaService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateRevistaCommand request, CancellationToken CancellationToken) 
        {
            List<Keywords>? keywords = null;
            List<Usuario>? autores = null;
            if (request.KeywordsNames is not null && request.KeywordsNames.Any())
            {
                keywords = await _keywordsRepository.GetByNamesAsync(request.KeywordsNames);
            }
            if (request.Autores is not null && request.Autores.Any())
            {
                 autores= await _usuarioRepository.GetByNamesAsync(request.Autores);
            }
            var revista = new Revista(
                request.titulo,
                request.descricao,
                request.publicacao,
                request.area,
                keywords
            );
            await _revistaRepository.AddAsync(revista);
            if (request.Arquivopdf != null)
                await _arquivoRevistaService.UploadAsync(revista.Id, request.Arquivopdf);

            if (request.Capa != null)
                await _arquivoRevistaService.UploadImagemAsync(revista.Id, request.Capa);
            return ResultViewModel<object>.Success(new { revista.Id });
        }
    }
}
