using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Service
{
    public interface IArquivoRevistaService
    {
        Task UploadAsync(Guid id, IFormFile arquivo);
        Task<byte[]> BaixarAsync(Guid id);
        Task UploadImagemAsync(Guid id, IFormFile imagem);
    }
}
