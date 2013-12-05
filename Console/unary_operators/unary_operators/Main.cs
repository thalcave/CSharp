using System;

class Unary
 {
    public static void Main()
     {
        int unary = 0;
        int preIncrement;
        int preDecrement;
        int postIncrement;
        int postDecrement;
        int positive;
        int negative;
        sbyte bitNot;
        bool logNot;


         preIncrement = ++unary;
         Console.WriteLine("pre-Increment: {0}", preIncrement);

         preDecrement = --unary;
         Console.WriteLine("pre-Decrement: {0}", preDecrement);

         postDecrement = unary--;
         Console.WriteLine("Post-Decrement: {0}", postDecrement);

         postIncrement = unary++;
         Console.WriteLine("Post-Increment: {0}", postIncrement);

         Console.WriteLine("Final Value of Unary: {0}", unary);

         positive = -postIncrement;
         Console.WriteLine("Positive: {0}", positive);

         negative = +postIncrement;
         Console.WriteLine("Negative: {0}", negative);

         bitNot = 0;
         bitNot = (sbyte)(~bitNot);
         Console.WriteLine("Bitwise Not: {0}", bitNot);

         logNot = false;
         logNot = !logNot;
         Console.WriteLine("Logical Not: {0}", logNot);

		double[,] double_matrix = new double[10, 10];

		string s1 = "Hello";	//string object is created and s1 is a reference to it
		string s2 = s1;		//s2 is a reference to string object
		Console.WriteLine("s1: {0} s2: {1}", s1, s2);

		s2 = s2.Replace("H", "CH");
		Console.WriteLine("s1: {0} s2: {1}", s1, s2);

		s1 = "World";		//a new string object is created and s1 is a reference to it
		Console.WriteLine("s1: {0} s2: {1}", s1, s2);	//s2 is a reference to old string object
     }
 }