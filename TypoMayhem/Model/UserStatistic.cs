using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.Model
{
	public class UserStatistic
	{
		// Properties
		public int Id { get; set; }
		public string? Username { get; set; }
		public int SessionDuration { get; set; }
		public int ErrorCount { get; set; }
		public double WordsPerMinute { get; set; }
		public double SignsPerMinute { get; set; }
	}
}
