namespace Booga_Compiler
{
	class Program
	{

		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.Error.WriteLine("Error: path to code not specified\nusage: boogac <path> [-c <assembly-name>]\n\nDefault behavior is to interpret the specified booga code, but the - c flag will compile the code into a c file");
				return;
			}
			if (!File.Exists(args[0]))
			{
				Console.Error.WriteLine("File does not exist");
				return;
			}
			if (args.Length > 1 && args[1] == "-c")
			{
				string output = Parser.ParseBFToC(Parser.ParseOogaToBF(File.OpenText(args[0]).ReadToEnd()));
				if (args.Length > 2)
				{
					File.WriteAllText($"./{args[2]}.c", output);
				}
				else
				{
					File.WriteAllText("./out.c", output);
				}
			}
			else
			{
				Interpreter.InterpretBooga(Parser.ParseOogaToBF(File.OpenText(args[0]).ReadToEnd()));
			}
		}
	}
}