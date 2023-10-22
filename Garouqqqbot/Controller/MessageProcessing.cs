using Garouqqqbot.Helper;
using Garouqqqbot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Garouqqqbot.Controller
{
	public  class MessageProcessing
	{
		ITelegramBotClient _botClient;
		Update _update;
		CancellationToken _cancellationToken;
		public MessageProcessing(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) 
		{
			_botClient = botClient;
			_update = update;
			_cancellationToken = cancellationToken;
			MessageProcess();
		}
		public async Task  MessageProcess()
		{
			try
			{
				var message = _update.Message;
				if (_update != null && _update.Message != null)
				{
					if (message.Text.Contains("/start")) 
					{

						long userid = message.Chat.Id;
						string phon = message.Chat.Location == null ? string.Empty : message.Chat.Location.ToString();
						string Last = message.Chat.LastName;
						string First = message.Chat.FirstName;
						string userName = message.Chat.Username;
						UserModel a = new()
						{
							UserId = userid,
							UserName = userName,
							LastName = Last,
							FerstName = First
						};

						await ControllerDB.InsertUser(a);
						Console.WriteLine($"Received a '{message.Text}' message in chat {message.Chat.Id},{phon},{userid},{userName}");
					}
					UserModel user = await ControllerDB.GetUserById(message.Chat.Id);
					APPstring.UserLang = user.UserLang;
					#region выбирети язык
					
					if (message.Text.Contains(APPstring.language))
					{

						await _botClient.SendTextMessageAsync(message.Chat.Id, APPstring.SelectLocalization, Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetLocalization());

					}
					#endregion
					#region выбрали язык
					if(APPstring.Choose.Any(w =>w == message.Text))
					{
						switch (message.Text)
						{
							case "ru🇷🇺":
								APPstring.UserLang = Localization.ru;
								await _botClient.SendTextMessageAsync(message.Chat.Id, "выбрали ru", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetMainKeyBoard());
								await ControllerDB.UpdateUserLocalization((byte)Localization.ru, message.Chat.Id);
								break;
							case "kz🇰🇿":
								APPstring.UserLang = Localization.kz;

								await _botClient.SendTextMessageAsync(message.Chat.Id, "Таңдау kz", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetMainKeyBoard());
								await ControllerDB.UpdateUserLocalization((byte)Localization.kz, message.Chat.Id);
								break;
							case "uz🇺🇿":
								APPstring.UserLang = Localization.uz;
								await _botClient.SendTextMessageAsync(message.Chat.Id, "Tanlamoq uz", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetMainKeyBoard());
								await ControllerDB.UpdateUserLocalization((byte)Localization.uz, message.Chat.Id);
								break;
							case "eng🇺🇸":
								APPstring.UserLang = Localization.eng;
								await _botClient.SendTextMessageAsync(message.Chat.Id, "выбрали eng", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetMainKeyBoard());
								await ControllerDB.UpdateUserLocalization((byte)Localization.eng, message.Chat.Id);
								break;
						}
					}
					
					#endregion
					if (message.Text.ToLower().Contains("здорова"))
					{
						
						await _botClient.SendTextMessageAsync(message.Chat.Id, "здорова", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, KeyBoards.GetMainKeyBoard());
						
					}

					
					if (message.Text.Contains(APPstring.SupportService))
					{

						//List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
						//buttons.Add(new InlineKeyboardButton("rwerwer") { Text = "wrewer"});
						//InlineKeyboardMarkup a = new InlineKeyboardMarkup(buttons.ToArray());



						List<UserModel> b = await ControllerDB.GetUser();
						if (message.Chat.Id == 5792003345)
						{
							List<InlineKeyboardButton> a = new List<InlineKeyboardButton>();

							foreach (UserModel f in b)
							{
								var x = InlineKeyboardButton.WithCallbackData($"{f.FerstName.Trim()},{f.UserName.Trim()},","My");
								
								
								a.Add(x);
							}
							InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(a);
							await _botClient.SendTextMessageAsync(message.Chat.Id, " 1", Telegram.Bot.Types.Enums.ParseMode.Html, null, false, false, false, 0, false, inlineKeyboardMarkup);
							//await InlineButtonMessage();
						}
					
					}
					if (message.Text.Contains(APPstring.StrAbout))
					{
						using (Stream a = System.IO.File.OpenRead("C:\\Users\\user\\ppppppppppppp.txt"))
						{
							InputOnlineFile inputFile = new InputOnlineFile(a);
							await _botClient.SendDocumentAsync(message.Chat.Id, inputFile);
						}
						using (Stream a = System.IO.File.OpenRead("C:\\Users\\user\\Moonlight.mp3"))
						{
							InputOnlineFile inputFile = new InputOnlineFile(a);
							await _botClient.SendAudioAsync(message.Chat.Id, inputFile);
						
							
						}

					}
				}
			}
			catch (Exception ex)
			{
				await Logs.Erorr($"{ex.Message},{ex.StackTrace}");
			}
			
			
			
		}
		//public async Task InlineButtonMessage()
		//{
				//while (true)
				//{
					//try
					//{
						//Thread.Sleep(10);
						//var Updats = await _botClient.GetUpdatesAsync();
							//foreach(var up in Updats)
						//{
								//if(up != null && up.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
							//{

							//}
						//}
					//}
					//catch (Exception ex)
					//{

					//}
				//}

		//}
	}
}
