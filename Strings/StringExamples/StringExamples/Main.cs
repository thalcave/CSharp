using System;
using System.Collections.Generic;

namespace StringExamples
{
	class StringExamples
	{
		private static void BoxingExample ()
		{
			List<object> mixedList = new List<object>();

			// Add a string element to the list. 
			mixedList.Add("First Group:");

			// Add some integers to the list.  
			for (int j = 1; j < 5; j++)
			{
			    // Rest the mouse pointer over j to verify that you are adding 
			    // an int to a list of objects. Each element j is boxed when  
			    // you add j to mixedList.
			    mixedList.Add(j);
			}

			// Add another string and more integers.
			mixedList.Add("Second Group:");
			for (int j = 5; j < 10; j++)
			{
			    mixedList.Add(j);
			}

			// Display the elements in the list. Declare the loop variable by  
			// using var, so that the compiler assigns its type. 
			foreach (var item in mixedList)
			{
			    // Rest the mouse pointer over item to verify that the elements 
			    // of mixedList are objects.
			    Console.WriteLine(item);
			}
		}
		private static string Concatenate(string text)
	    {
	        // Use StringBuilder for concatenation in tight loops.
	        System.Text.StringBuilder sb = new System.Text.StringBuilder(text);
	        for (int i = 0; i < 100; i++)
	        {
	            //sb.AppendLine(i.ToString());
				sb.Append(i.ToString());
	        }
			return sb.ToString();
	    }
		private static string ReverseString (string str)
		{
			System.Text.StringBuilder str_builder = new System.Text.StringBuilder(str);

			int start = 0;
			int end = str.Length - 1;
			while (start < end) {
				char tmp = str_builder[start];
				str_builder[start] = str_builder[end];
				str_builder[end] = tmp;

				++start;
				--end;
			}

			return str_builder.ToString();
		}

		public static void Main()
		{
			string str = "hello";
			string nullStr = null;
			string emptyStr = String.Empty;

			string tempStr = str + nullStr;
			// Output of the following line: hello
			Console.WriteLine(tempStr);

			bool b = (emptyStr == nullStr);
			// Output of the following line: False
			Console.WriteLine(b);

			// The following line creates a new empty string. 
			string newStr = emptyStr + nullStr;

			// Null strings and empty strings behave differently. The following 
			// two lines display 0.
			Console.WriteLine(emptyStr.Length);
			Console.WriteLine(newStr.Length);
			// The following line raises a NullReferenceException. 
			//Console.WriteLine(nullStr.Length); 

			// The null character can be displayed and counted, like other chars. 
			string s1 = "\x0" + "abc";
			string s2 = "abc" + "\x0";
			// Output of the following line: * abc*
			Console.WriteLine("*" + s1 + "*");
			// Output of the following line: *abc *
			Console.WriteLine("*" + s2 + "*");
			// Output of the following line: 4
			Console.WriteLine(s2.Length);

			Console.WriteLine("reverse of '{0}' is '{1}'", str, ReverseString(str));

			Console.WriteLine("Concatenate: {0}", Concatenate(s1));

			BoxingExample();
		}
	}
}
