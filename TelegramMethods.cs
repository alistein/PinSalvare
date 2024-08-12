using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PinSalvareBot;

public static class TelegramMethods
{

    public static async Task SendVideoToUserAsync(ITelegramBotClient botClient, long chatId, string videoUrl)
    {
        await botClient.SendVideoAsync(
            chatId: chatId,
            video: new InputFileUrl(videoUrl),
            caption: "Buyur ayqa"
        );
    }


    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {

        var configurationModel = ConfigurationManager.Configure();

        if (update.Type == UpdateType.Message && !string.IsNullOrEmpty(update.Message?.Text))
        {
            var userId = update.Message.From?.Id.ToString().Trim();

            string messageText = update.Message.Text;

            long chatId = update.Message.Chat.Id;

            if (userId == null || !configurationModel.AllowedUsers!.Contains(userId))
            {
                await botClient.SendTextMessageAsync(chatId, "You are not allowed!", cancellationToken: cancellationToken);

                return;
            }

            if (Utils.ValidatePinLink(messageText))
            {
                await botClient.SendTextMessageAsync(chatId, "Getdiyyyy eeeee....", cancellationToken: cancellationToken);

                PinterestApiResponse? videoUrl = null;

                try
                {
                    videoUrl = await Utils.GetVideoUrlFromApiAsync(messageText);
                }
                catch (Exception)
                {
                    await botClient.SendTextMessageAsync(chatId, "Videonu linkini tapa bilmədim😔", cancellationToken: cancellationToken);
                }


                if (videoUrl is null or { Data.Url: null })
                {
                    await botClient.SendTextMessageAsync(chatId, "Başaramadık abi affet🥹", cancellationToken: cancellationToken);
                }

                await botClient.SendTextMessageAsync(chatId, "Yükləyirəm gözlə🦊....", cancellationToken: cancellationToken);

                try
                {
                    await SendVideoToUserAsync(botClient, chatId, videoUrl?.Data?.Url!);
                }
                catch (Exception)
                {
                    await botClient.SendTextMessageAsync(chatId, "Videonu yükləyə bilmədim telegramın səhvidi😝", cancellationToken: cancellationToken);
                }

            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "Sadəcə pinterest linkləri qəbul edirem🥰");
            }
        }
    }
}
