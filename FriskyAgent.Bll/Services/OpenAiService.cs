// В вашем BLL-проекте подключите
// <PackageReference Include="System.Net.Http.Json" Version="*" />

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using FriskyAgent.Bll.Models;       // где лежат GPTRequestModel, GPTMessageModel и т.д.

namespace FriskyAgent.Bll.Services
{
    /// <summary>
    /// Обычный HTTP-сервис для работы с OpenAI Chat API.
    /// </summary>
    public interface IOpenAiService
    {
        /// <summary>
        /// Отправляет запрос и возвращает десериализованную модель ответа.
        /// </summary>
        Task<GPTResponseModel> SendChatCompletionAsync(
            GPTRequestModel request,
            CancellationToken ct = default
        );
    }

    public class OpenAiService : IOpenAiService, IDisposable
    {
        private readonly HttpClient _http;
        private bool _disposed;

        // Больше не IConfiguration, только HttpClient
        public OpenAiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<GPTResponseModel> SendChatCompletionAsync(
            GPTRequestModel request,
            CancellationToken ct = default
        )
        {
            using var resp = await _http.PostAsJsonAsync("v1/chat/completions", request, ct);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<GPTResponseModel>(cancellationToken: ct);
            return result ?? throw new InvalidOperationException("Пустой ответ от OpenAI");
        }

        public void Dispose()
        {
            if (!_disposed) { _http.Dispose(); _disposed = true; }
        }
    }
}
