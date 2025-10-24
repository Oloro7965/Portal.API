using OpenAI;
using OpenAI.Chat;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly ChatClient _chatClient;

        public KeywordService(string apiKey, string model = "gpt-4")
        {
            // Inicializa o ChatClient com modelo e API key
            _chatClient = new ChatClient(model: model, apiKey: apiKey);
        }

        public async Task<List<string>> ExtractKeywordsAsync(string userQuery)
        {
            // Prompt para a IA gerar keywords
            //var prompt = $"Liste palavras-chave separadas por vírgula relacionadas a: {userQuery}";
            var prompt = $"""
                Extraia palavras-chave relevantes do seguinte texto de pesquisa do usuário.
                Responda apenas com uma lista de palavras-chave separadas por vírgulas, sem explicações adicionais.
                Texto: {userQuery}
                """;

            // Chama a IA
            var response = await _chatClient.CompleteChatAsync(prompt);

            var chatCompletion = response.Value;

            if (chatCompletion == null || chatCompletion.Content.Count == 0)
                return new List<string>();

            // Pega o conteúdo da primeira mensagem gerada
            var text = chatCompletion.Content[0].Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            // Separa em palavras-chave
            return text
                .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToList();
        }
    }
}
