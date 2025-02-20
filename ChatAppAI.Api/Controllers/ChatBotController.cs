using ChatAppAI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppAI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatBotController(ChatBotService chatBotService) : ControllerBase
{
    [HttpPost("chat")]
    public async Task<IActionResult> ChatWithBot([FromBody] string userMessage) => Ok(await chatBotService.GetBotResponse(userMessage));

}