using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using AudioToText.Api.Services;
using AudioToText.Api.Models;

namespace AudioToText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranscriptionController : ControllerBase
    {
        private readonly TranscriptionService _transcriptionService;

        public TranscriptionController(TranscriptionService transcriptionService)
        {
            _transcriptionService = transcriptionService;
        }

        [HttpPost("transcribe")]
        public async Task<IActionResult> Transcribe([FromForm] IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("No audio file uploaded.");
            }

            using (var stream = new MemoryStream())
            {
                await audioFile.CopyToAsync(stream);
                var transcriptionResult = await _transcriptionService.TranscribeAudio(stream.ToArray());
                return Ok(transcriptionResult);
            }
        }
    }
}