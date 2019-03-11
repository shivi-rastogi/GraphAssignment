using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.Write("ReverseString - Enter string value: ");
                //string str = Console.ReadLine();
                //Console.WriteLine(Functions.ReverseString(str));


                //Console.Write("CalculateNthFibonacciNumber - Enter value of N: ");
                //int N = int.Parse(Console.ReadLine());
                //Console.WriteLine(Functions.CalculateNthFibonacciNumber(N));


                //Console.Write("PadNumberWithZeroes - Enter value of N: ");
                //int Num = int.Parse(Console.ReadLine());
                //Console.WriteLine(Functions.PadNumberWithZeroes(Num));


                //Console.Write("FindNthLargestNumber - Enter comma seperated integer list: ");
                //List<int> numbers = Console.ReadLine().Replace(" ", "").Split(',').Select(x=> int.Parse(x)).ToList<int>();
                //Console.Write("Enter value of N: ");
                //int N = int.Parse(Console.ReadLine());
                //Console.WriteLine(Functions.FindNthLargestNumber(numbers, N ));


                //Console.Write("SelectPrimeNumbers - Enter comma seperated integer list: ");
                //IEnumerable<int> primeNumbers = Console.ReadLine().Replace(" ", "").Split(',').Select(x => int.Parse(x));
                //Console.WriteLine("PrimeNumberList - ");
                //Functions.SelectPrimeNumbers(primeNumbers).ToList().ForEach(x => Console.WriteLine(string.Format("{0},",x)));

                //Console.Write("IsPalindrome - Enter a number: ");
                //int pNum = int.Parse(Console.ReadLine());
                //Console.WriteLine(string.Format("IsPalindrome= {0} ",Functions.IsPalindrome(pNum)));

                Console.Write("CountSetBits - Enter a number: ");
                int bNum = int.Parse(Console.ReadLine());
                Console.WriteLine(string.Format("Set bit Count is= {0} ", Functions.CountSetBits(bNum)));

                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
