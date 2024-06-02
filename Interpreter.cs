namespace Booga_Compiler
{
	internal class Interpreter
	{
		public static void InterpretBooga(string code)
		{
			List<int> labels = [];
			byte[] m = new byte[30000];
			Array.Fill(m, (byte) 0);
			int i = 0;
			for (int j = 0;j < code.Length;j++)
			{
				char c = code[j];
				switch (c)
				{
					case '+':
						m[i]++;
						break;
					case '-':
						m[i]--;
						break;
					case '>':
						i++;
						break;
					case '<':
						i--;
						break;
					case '.':
						Console.Write(Convert.ToChar(m[i]));
						break;
					case ',':
						m[i] = (byte) Console.ReadKey().KeyChar;
						break;
					case '[':
						if (m[i] != (char) 0)
						{
							labels.Add(j);
						}
						else
						{
							SeekEndOfLoop(ref j, code);
						}
						break;
					case ']':
						if (m[i] != (char) 0)
						{
							j = labels.Last();
						}
						else
						{
							labels.Remove(labels.Last());
						}
						break;
				}
			}
		}
		static void SeekEndOfLoop(ref int j, string code)
		{
			char c = code[j];
			int outOfScopeNum = 1;
			while (c != ']' || outOfScopeNum != 0)
			{
				j++;
				c = code[j];
				if (c == '[')
				{
					outOfScopeNum++;
				}
				else if (c == ']' && outOfScopeNum != 0)
				{
					outOfScopeNum--;
				}
			}
		}
	}
}
