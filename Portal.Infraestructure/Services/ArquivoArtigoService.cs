using Microsoft.AspNetCore.Http;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Services
{
    public class ArquivoArtigoService : IArquivoArtigoService
    {
        private readonly IArtigoRepository _artigoRepository;

        public ArquivoArtigoService(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        public async Task<byte[]> BaixarAsync(Guid id)
        {
            var artigo = await _artigoRepository.GetByIdAsync(id)
            ?? throw new Exception("Artigo não encontrado");

            return artigo.arquivopdf ?? throw new Exception("Arquivo não encontrado");
        }

        public async Task UploadAsync(Guid id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
                throw new ArgumentException("Arquivo inválido");
            if (arquivo.ContentType != "application/pdf")
                throw new ArgumentException("Somente arquivos PDF são permitidos");
            using var ms = new MemoryStream();
            await arquivo.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var revista = await _artigoRepository.GetByIdAsync(id)
                ?? throw new Exception("Artigo não encontrado");

            revista.DefinirArquivoPdf(bytes);
            await _artigoRepository.SaveChangesAsync();
        }
    }
}
