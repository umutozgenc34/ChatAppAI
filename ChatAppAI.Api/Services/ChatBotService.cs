using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using Betalgo.Ranul.OpenAI.ObjectModels;

namespace ChatAppAI.Api.Services;

public class ChatBotService(IOpenAIService openAIService)
{
    public async Task<string> GetBotResponse(string userMessage)
    {
        var chatCompletionRequest = new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
        {
            ChatMessage.FromSystem("You are a helpful assistant."),
            ChatMessage.FromUser(userMessage)

        },

            Model = Models.Gpt_3_5_Turbo,
            MaxTokens = 200
        };

        var response = await openAIService.ChatCompletion.CreateCompletion(chatCompletionRequest);

        if (response.Successful && response.Choices.FirstOrDefault()?.Message?.Content != null)
        {
            return response.Choices.First().Message.Content.Trim();
        }

        return "Yanıt alınamadı";
    }
}