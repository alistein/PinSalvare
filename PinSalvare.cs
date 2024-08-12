using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PinSalvareBot
{
    public class PinSalvare
    {
        private readonly ILogger<PinSalvare> _logger;

        public PinSalvare(ILogger<PinSalvare> logger)
        {
            _logger = logger;
        }

        [Function("PinSalvareUpdate")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var cst = new CancellationTokenSource();

            try
            {

                var configurationModel = ConfigurationManager.Configure();

                _logger.LogInformation(Environment.GetEnvironmentVariable("AllowedUsers"));

                var request = await new StreamReader(req.Body).ReadToEndAsync();

                var update = JsonConvert.DeserializeObject<Update>(request);

                var botClient = new TelegramBotClient(configurationModel.BotToken ?? throw new Exception("Bot token not found"));

                await TelegramMethods.HandleUpdateAsync(botClient, update, cst.Token);

                var me = await botClient.GetMeAsync();

                return new OkObjectResult($" Mən {me.Id} - Videonun linkini at qalanını fikirləşmə! men ise body: {request}");
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                _logger.LogError(e.InnerException?.Message);
                _logger.LogError(e.Source);

                cst.Cancel();

                return new BadRequestObjectResult("Problem");
            }

        }
    }
}
