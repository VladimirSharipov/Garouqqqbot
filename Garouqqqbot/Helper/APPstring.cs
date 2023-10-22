using Garouqqqbot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garouqqqbot.Helper
{
	public static class APPstring
	{
		public static List<String> Choose { get; set; } = new List<string> { "kz🇰🇿", "uz🇺🇿", "ru🇷🇺", "eng🇺🇸" };
		public static Localization UserLang { get; set; }
		public static string SelectLocalization {
			get
			{
				if (UserLang == Localization.kz)
				{
					return "Таңдау";
				}
				else if (UserLang == Localization.eng)
				{
					return "Choose";
				}
				else if (UserLang == Localization.ru)
				{
					return "выберите";
				}
				else
				{
					return "Tanlamoq";
				}
			}
		}
		public  static string StrAbout 
		{
			get
			{
				if (UserLang == Localization.kz)
				{
					return "Біз туралы";
				}
				else if (UserLang == Localization.eng)
				{
					return "About as";
				}
				else if (UserLang == Localization.ru)
				{
					return "О нас";
				}
				else
				{
					return "Biz haqimizda";
				}
			}
		}
		public static string SupportService
		{
			get
			{
				if (UserLang == Localization.kz)
				{
					return "Қолдау қызметі";
				}
				else if (UserLang == Localization.eng)
				{
					return "Support Service😀";
				}
				else if (UserLang == Localization.ru)
				{
					return "Служба поддержки";
				}
				else
				{
					return "Qo'llab-quvvatlash xizmati";
				}
			}
		}
		public static string language
		{
			get
			{
				if (UserLang == Localization.kz)
				{
					return "тіл";
				}
				else if (UserLang == Localization.eng)
				{
					return "language";
				}
				else if (UserLang == Localization.ru)
				{
					return "Язык";
				}
				else
				{
					return "til";
				}
			}
		}
		public static string Botdocumentation
		{
			get
			{
				if (UserLang == Localization.kz)
				{
					return "Бот құжаттамасы";
				}
				else if (UserLang == Localization.eng)
				{
					return "Bot documentation";
				}
				else if (UserLang == Localization.ru)
				{
					return "документация бота";
				}
				else
				{
					return "Bot hujjatlari";
				}
			}
		}
	}
}
