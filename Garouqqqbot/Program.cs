using Garouqqqbot.Controller;
using Garouqqqbot.Model;
using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient(Config.ApiTelegramToken);

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
	AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

botClient.StartReceiving(
	updateHandler: HandleUpdateAsync,
	pollingErrorHandler: HandlePollingErrorAsync,
	receiverOptions: receiverOptions,
	cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot 
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
	MessageProcessing a = new(botClient, update, cancellationToken);
	
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
	var ErrorMessage = exception switch
	{
		ApiRequestException apiRequestException
			=> $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
		_ => exception.ToString()
	};
	Console.WriteLine(ErrorMessage);
	return Task.CompletedTask;
}
