using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portal.Core.Repositories;
using Portal.Core.Service;
using Portal.Infraestructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Services
{
    public class ArquivoRevistaService : IArquivoRevistaService
    {
        private readonly IRevistaRepository _revistaRepository;

        public ArquivoRevistaService(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }

        public async Task<byte[]> BaixarAsync(Guid id)
        {
            var artigo = await _revistaRepository.GetByIdAsync(id)
            ?? throw new Exception("Revista não encontrada");

            return artigo.arquivopdf ?? throw new Exception("Revista não encontrada");
        }

        public async Task UploadAsync(Guid id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
                throw new ArgumentException("Arquivo inválido");

            using var ms = new MemoryStream();
            await arquivo.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var revista = await _revistaRepository.GetByIdAsync(id)
                ?? throw new Exception("Revista não encontrada");
            revista.DefinirArquivoPdf(bytes);
            await _revistaRepository.UpdateAsync(revista);
        }
        public async Task UploadImagemAsync(Guid id, IFormFile imagem)
        {
            if (imagem == null || imagem.Length == 0)
                throw new ArgumentException("Imagem inválida");

            using var ms = new MemoryStream();
            await imagem.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var revista = await _revistaRepository.GetByIdAsync(id)
                ?? throw new Exception("Revista não encontrada");

            revista.DefinirCapa(bytes);
            await _revistaRepository.UpdateAsync(revista);
        }
    }
}
