using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    public static class KaratsubaMultiplication
    {
        public static string Multiply(string number1, string number2)
        {
            // assuming that x and y are both positive 

            var maxLength = Math.Max(number1.Length, number2.Length);

            if(maxLength > 1 && maxLength % 2 > 0)
            {
                // make maxLength even for double digit multiplication
                maxLength = maxLength + 1;
            }

            // make same length
            string x = number1.PadLeft(maxLength, '0');
            string y = number2.PadLeft(maxLength, '0');

            var n = x.Length;

            // base case
            if (n == 1)
            {
                // C# allows implicit conversion from char to ushort so this will work
                // basically,this is computing the difference in unicide of given digit and '0''s unicode
                return ((x[0] - '0') * (y[0] - '0')).ToString();
            }

            // Start Karatsuba's algorithm
            var a = x.Substring(0, n / 2);
            var b = x.Substring(n / 2);
            var c = y.Substring(0, n / 2);
            var d = y.Substring(n / 2);

            var ac = Multiply(a, c);
            var bd = Multiply(b, d);

            var aPlusB = a.Add(b);
            var cPlusD = c.Add(d);
            var aPlusBTimesCPlusD = Multiply(aPlusB, cPlusD);

            var adbc = aPlusBTimesCPlusD.Subtract(ac).Subtract(bd);

            return ac.Times10Power(n).Add(adbc.Times10Power(n / 2)).Add(bd);
        }

        public static string Add(this string x, string y)
        {
            string a = x.PadLeft(y.Length, '0');
            string b = y.PadLeft(x.Length, '0');

            a = reverse(a);
            b = reverse(b);

            StringBuilder sb = new StringBuilder();

            int carryOver = 0;

            for (int i = 0; i < a.Length; i++)
            {
                var sum = (a[i] - '0') + (b[i] - '0') + carryOver;

                carryOver = sum / 10;

                sb.Append((sum < 10 ? sum : Math.Abs(sum - 10)).ToString());
            }

            if (carryOver > 0)
            {
                sb.Append(carryOver);
            }

            return reverse(sb.ToString());
        }

        public static string Subtract(this string x, string y)
        {
            string a = x.PadLeft(y.Length, '0');
            string b = y.PadLeft(x.Length, '0');

            a = reverse(a);
            b = reverse(b);

            StringBuilder sb = new StringBuilder();

            int borrow = 0;

            for (int i = 0; i < a.Length; i++)
            {
                var diff = (a[i] - '0') - (b[i] - '0') - borrow;

                borrow = diff < 0 ? 1 : 0;

                sb.Append((diff >= 0 ? diff : (10 + diff)).ToString());
            }

            return reverse(sb.ToString());
        }

        public static string Times10Power(this string a, int n)
        {
            return a.PadRight(a.Length + n, '0');
        }

        static string reverse(string s)
        {
            var reveredStringArray = s.ToCharArray();

            Array.Reverse(reveredStringArray);

            return new string(reveredStringArray); 
        }
    }

   
}
