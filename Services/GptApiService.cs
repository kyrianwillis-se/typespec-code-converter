using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypeSpecCodeConverter.Configuration;

namespace TypeSpecCodeConverter.Services
{
    public class GptApiService : IGptApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationConfig _config;
        private readonly IFileService _fileService;

        public GptApiService(HttpClient httpClient, IOptions<ApplicationConfig> config, IFileService fileService)
        {
            _httpClient = httpClient;
            _config = config.Value;
            _fileService = fileService;
        }

        public async Task<string> CallGpt4Api(string content)
        {
            var setupContent = _fileService.GetPrompt("ConversionInstructions.txt");

            var requestBody = new
            {
                model = "gpt-4",
                temperature = 0.0,
                max_tokens = 3000,
                messages = new[]
                {
                    new { role = "system", content = "You are an assistant that analyzes typespec files and helps generate C# code from them. Please respond concisely and only provide the code unless more information is requested." },
                    new { role = "user", content = setupContent + "\nconvert the following type spec code to C#\n" + content }
                }
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "sk-proj-8hzWEHuxCD0Q0wHuIpPDT3BlbkFJxehy20DuJ26krTCJMngm");

            var response = await _httpClient.PostAsync($"https://api.openai.com/v1/chat/completions?conversation_id={_config.Paths["ConversationId"]}", requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(responseContent);
            var result = jsonResponse.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            return result;
        }
    }
}
