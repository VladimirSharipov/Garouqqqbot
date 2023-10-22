using Garouqqqbot.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Garouqqqbot.Model
{
	public static class KeyBoards
	{
		
		public static ReplyKeyboardMarkup GetMainKeyBoard()
		{
			
			List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();
			buttons.Add(new KeyboardButton[]
			{
				new KeyboardButton(APPstring.SupportService),
				new KeyboardButton(APPstring.StrAbout)
			});
			buttons.Add(new KeyboardButton[]
			{
				new KeyboardButton(APPstring.language),
				new KeyboardButton(APPstring.Botdocumentation)
			});
			var Keyboard = new ReplyKeyboardMarkup(buttons);
			return Keyboard;
		}
		public static ReplyKeyboardMarkup GetLocalization()
		{
			
			List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();
			buttons.Add(new KeyboardButton[]
			{
				new KeyboardButton("ru🇷🇺"),
				new KeyboardButton("kz🇰🇿")


			});
			buttons.Add(new KeyboardButton[]
			{
				new KeyboardButton("eng🇺🇸"),
				new KeyboardButton("uz🇺🇿")


			});
			var Keyboard = new ReplyKeyboardMarkup(buttons);
			return Keyboard;
		}
	}
}
