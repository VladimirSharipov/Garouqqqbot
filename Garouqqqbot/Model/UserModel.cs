using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garouqqqbot.Model
{
	public class UserModel
	{
		public long UserId { get; set; }
		public string UserName { get; set; }
		public string LastName { get; set; }
		public string FerstName { get; set; }
		public Localization UserLang { get; set; }
	}
}
