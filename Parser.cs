namespace Booga_Compiler
{
	class Parser()
	{
		public static string ParseOogaToBF(string ooga)
		{
			string[] words = ooga.Split([' ']);
			string output = "";
			foreach (string word in words)
			{
				switch (word)
				{
					case "ooga":
						output += "+";
						break;

					case "booga":
						output += "-";
						break;

					case "unga":
						output += ">";
						break;

					case "bunga":
						output += "<";
						break;

					case "ongo":
						output += "[";
						break;

					case "bongo":
						output += "]";
						break;

					case "munga":
						output += ".";
						break;

					case "gunga":
						output += ",";
						break;
				}
			}
			return output;
		}

		public static string ParseBFToC(string BF)
		{
			string output = "#include <stdio.h>\nint main(){char m[30000] = {0}; int i = 0;";
			foreach (char c in BF)
			{
				switch (c)
				{
					case '+':
						output += "m[i]++;";
						break;
					case '-':
						output += "m[i]--;";
						break;
					case '>':
						output += "i++;";
						break;
					case '<':
						output += "i--;";
						break;
					case '.':
						output += "putchar(m[i]);";
						break;
					case ',':
						output += "m[i] = getchar();";
						break;
					case '[':
						output += "while(m[i] != 0){";
						break;
					case ']':
						output += "}";
						break;
				}
			}
			output += "}";
			return output;
		}
	}
}