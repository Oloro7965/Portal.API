using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Service
{
    public interface IEmbeddingService
    {
        Task<List<float>> GerarEmbeddingAsync(string texto);
    }
}
