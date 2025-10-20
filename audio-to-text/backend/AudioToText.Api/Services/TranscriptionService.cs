using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AudioToText.Api.Services
{
    public class TranscriptionService
    {
        private readonly HttpClient _httpClient;

        public TranscriptionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> TranscribeAudio(Stream audioStream)
        {
            using var content = new StreamContent(audioStream);
            content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/audio/transcriptions", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transcriptionResult = JsonConvert.DeserializeObject<TranscriptionResult>(jsonResponse);

            return transcriptionResult.TranscribedText;
        }
    }

    public class TranscriptionResult
    {
        [JsonProperty("text")]
        public string TranscribedText { get; set; }
    }
}