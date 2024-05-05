using System;
using System.Collections.Generic;

Console.WriteLine("Enter your string, please");
string text = Console.ReadLine();
Anagram myAnagram = new ();
Console.WriteLine(myAnagram.Reverse(text));
Console.ReadKey();
