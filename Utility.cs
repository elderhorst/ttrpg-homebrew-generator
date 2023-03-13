namespace Homebrew
{
	public static class Utility
	{
		public static string FormatNumber(string number)
		{
			number = number.Trim().ToLower();
			
			if (number.Equals("cantrip") || number.Equals("0"))
			{
				return "cantrip";
			}
			
			char value = number[number.Length - 1];
			
			switch (value)
			{
				case '1':
					return $"{number}st";
				case '2':
					return $"{number}nd";
				case '3':
					return $"{number}rd";
				default:
					return $"{number}th";
			}
		}
		
		public static string FormatNumber(int number)
		{
			return FormatNumber(number.ToString());
		}
	}
}