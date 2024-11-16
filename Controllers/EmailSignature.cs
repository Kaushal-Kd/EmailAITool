using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DynotreeServices.Controllers
{
    [ApiController]
    [Route("email/parser")]
    public class EmailSignature : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        [HttpPost("parseSignature")]
        public async Task<IActionResult> ParseSignature(Input html)
        {

            if (string.IsNullOrWhiteSpace(html.Html))
            {
                return BadRequest("The htmlBody field is required.");
            }

            string apiKey = ""; // Replace with your actual API key
            var result = await ExtractUserDetails(apiKey, html.Html);
            return Ok(result);
        }

        private async Task<string> ExtractUserDetails(string apiKey, string htmlBody)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = $"Extract user details from the following HTML email signature and return as a JSON object:\n{htmlBody}" }
                },
                temperature = 0
            };

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
