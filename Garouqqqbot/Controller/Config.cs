using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garouqqqbot.Controller
{
	public static class Config
	{
		public static readonly string ApiTelegramToken = ConfigurationManager.AppSettings["TelegramToken"];
		public static readonly string DBPath = ConfigurationManager.AppSettings["DBConnectingString"];
	}
}
