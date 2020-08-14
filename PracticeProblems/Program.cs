using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PracticeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(KaratsubaMultiplication.Multiply("123456789", "123456789").TrimStart('0'));
            Console.WriteLine(123456789L * 123456789);
        }      
    }   
}
