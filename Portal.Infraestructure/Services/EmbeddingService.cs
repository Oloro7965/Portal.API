using OpenAI;
using OpenAI.Embeddings;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Services
{
    public class EmbeddingService : IEmbeddingService
    {
        private readonly EmbeddingClient _client;

        public EmbeddingService(EmbeddingClient client)
        {
            _client = client;
        }

        public async Task<List<float>> GerarEmbeddingAsync(string texto)
        {
            // Gera o embedding usando o método correto
            var embedding = await _client.GenerateEmbeddingAsync(texto);

            // Retorna o vetor de floats
            return new List<float>(embedding.Value.ToFloats().ToArray());
        }
    }
}
