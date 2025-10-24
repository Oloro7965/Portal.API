using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces
{
    public interface IEmbeddingService
    {
        Task<List<float>> GerarEmbeddingAsync(string texto);
    }
}
