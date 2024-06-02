namespace Booga_Compiler
{
	class Program
	{

		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.Error.WriteLine("Enter the path to the file");
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