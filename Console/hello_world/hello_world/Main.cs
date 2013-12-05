using System;	//tells the compiler to use System as a candidate prefix for types used in the source code

 /* compiler first searches a name in current assembly
 * if not found, searches in all referenced assemblies
 * then it searches for System.name
 */

namespace hello_world
{
	class MainClass
	{
		private static string reverseString (string str)
		{
			char[] charArray = str.ToCharArray();
    		Array.Reverse( charArray );
    		return new string( charArray );
		}
		/*
		 * The static keyword makes the method accessible without an instance of Program. 
		 * Each console application's Main entry point must be declared static. 
		 * Otherwise, the program would require an instance, but any instance would require a program = circular dependency
		 */
		public static void Main (string[] args)
		{
			int no_args = args.GetLength (0);
			if (no_args > 0) {
				Console.WriteLine("Provided arguments:");
				for (int i = 0; i < no_args; ++i)
				{
					System.Console.Write(args[i]);
					System.Console.Write(" ");
				}
			}
			System.Console.WriteLine("Number of arguments: " + args.GetLength(0).ToString());
			System.Console.WriteLine("Input text:\n");
			string read_line = Console.ReadLine();
			Console.WriteLine("Reversed string: " + reverseString(read_line));

			Console.WriteLine("Input an integer value: ");
			UInt32 read_no = Convert.ToUInt32(Console.ReadLine());
			Console.WriteLine("Read this number: {0}", read_no);
		}
	}
}
