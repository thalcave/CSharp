using System;

namespace SimpleClass
{
	public class SimpleClass
	{
		public int number;
		public SimpleClass()
		{
			number = 0;
			Console.WriteLine("Simple Class created");
		}

		public String toString()
		{
			return Convert.ToString(number);
		}

	}

	class Program
	{
		public static void Main ()
		{
			SimpleClass sc = new SimpleClass();
			SimpleClass sc2 = sc;
			SimpleClass sc3 = null;

			if (sc == sc2) {
				Console.WriteLine("the 2 objects are identical");
			}

			//if (sc3 == null)	//use of unassigned local variable
			if (Object.Equals(sc3, null))
			{
				Console.WriteLine("Null object!");
			}

			Console.WriteLine(sc.toString());
			sc2.number = 10;
			Console.WriteLine(sc.toString());

			Console.WriteLine("sc == sc2 ? {0}", sc == sc2);
			Console.WriteLine("Equals(sc,sc2) ? {0}", Equals(sc, sc2));

			/*
			 * When a program declares two or more identical string variables, the compiler stores them all in the same location. 
			 * By calling the ReferenceEquals method, you can see that the two strings actually refer to the same object in memory. 
			 */
			string s1 = "abc";
			string s2 = "abc";
			string s3 = String.Copy(s1);

			Console.WriteLine("Equals(s1,s2) ? {0}", Equals(s1, s2));	//True - value
			Console.WriteLine("s1 == s2 ? {0}", s1 == s2);	//True - value
			Console.WriteLine("String.ReferenceEqual(s1,s2) ? {0}", String.ReferenceEquals(s1,s2));	//True - value
			Console.WriteLine("String.ReferenceEqual(s1,s3) ? {0}", String.ReferenceEquals(s1,s3));	//False
		}
	}
}

