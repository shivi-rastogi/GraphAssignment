using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Functions
    {

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value">String to reverse.</param>
        /// <returns>Reversed string.</returns>
        public static string ReverseString(string value)
        {
            return new String(value.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Calculates the Nth fibonacci number.
        /// </summary>
        /// <param name="n">Fibonacci number to calculate.</param>
        /// <returns>The nth fibonacci number.</returns>
        public static int CalculateNthFibonacciNumber(int n)
        {
            int[] series = new int[n + 1];
            series[0] = 0;
            series[1] = 1;
            for (int i=2; i<=n; i++)
            {
                series[i] = series[i - 1] + series[i - 2];


            }
            return series[n];
        }

        /// <summary>
        /// Pads a number with up to four zeroes, returning a string with a total length of five numerical characters.
        /// </summary>
        /// <param name="number">Number to pad.</param>
        /// <returns>Zero-padded number.</returns>
        /// <remarks>Can only pad unsigned numbers up to 99999.</remarks>
        public static string PadNumberWithZeroes(int number)
        {
            if (number < 0 || number > 99999)
                throw new FormatException("Number entered is out of range");
            return number.ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// Determines if a year is a leap year.
        /// </summary>
        /// <param name="year">Year to determine.</param>
        /// <returns>True if leap year, false if not.</returns>
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 ? true : false;
        }

        /// <summary>
        /// Find the N:th largest number in a range of numbers.
        /// </summary>
        /// <param name="numbers">List of integers.</param>
        /// <returns>The third largest number in list.</returns>
        public static int FindNthLargestNumber(List<int> numbers, int nthLargestNumber)
        {
            numbers.Sort();
            return numbers[numbers.Count() - nthLargestNumber];
        }

        /// <summary>
        /// Selects all prime numbers from an enumerable with numbers.
        /// </summary>
        /// <param name="numbers">Enumerable with numbers.</param>
        /// <returns>An enumerable with only prime numbers.</returns>
        public static IEnumerable<int> SelectPrimeNumbers(IEnumerable<int> numbers)
        {
            
            List<int> primelist = new List<int>();
            numbers = numbers.Where(x => ((x % 2 != 0) && x != 1 && x != 0) || x == 2);
            foreach (int num in numbers)
            {
                bool isPrime = true;
                for (int i=3; i<num/2; i=i+2)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                  primelist.Add(num);
            }
            return primelist;
        }

        /// <summary>
        /// Determines if the bit pattern of value the same if you reverse it.
        /// </summary>
        /// <param name="value">Value to inspect.</param>
        /// <returns>True if the bit value is a palindrome otherwise false.</returns>
        public static bool IsPalindrome(int value)
        {
            BitArray b = new BitArray(new int[] { value });
            for (int i =0; i<b.Length/2; i++)
            {
                if (b[i] != b[b.Length - 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Counts all set bits in an int value.
        /// </summary>
        /// <param name="value">Integer value to count bits in.</param>
        /// <returns>Number of set bits in integer value.</returns>
        public static int CountSetBits(int value)
        {
            int counter = 0;
            BitArray b = new BitArray(new int[] { value });
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                    counter++;
            }
            return counter;
        }
    }
}
