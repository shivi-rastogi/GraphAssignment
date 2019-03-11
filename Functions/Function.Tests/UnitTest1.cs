using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Functions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReverseString()
        {
           string reverse= Functions.ReverseString("whitespaces");
            Assert.AreEqual(reverse, "secapsetihw");
        }
        [TestMethod]
        public void TestCalculateNthFibonacciNumber()
        {
            //1,1,2,3,5,8,13,21,34,55,89,144
            int N = Functions.CalculateNthFibonacciNumber(10);
            Assert.AreEqual(N, 55);
        }
        [TestMethod]
        public void PadNumberWithZeroes()
        {
           
            string pStr = Functions.PadNumberWithZeroes(992);
            Assert.AreEqual(pStr, "00992");
        }

        [TestMethod]
        public void TestIsLeapYear()
        {
           
            bool Isleap = Functions.IsLeapYear(2016);
            Assert.IsTrue(Isleap);

             Isleap = Functions.IsLeapYear(2006);
            Assert.IsFalse(Isleap);
        }


        [TestMethod]
        public void TestFindNthLargestNumber()
        {
            List<int> lst = new List<int> { 100, 1212, 0, 3, 22 };
            int nthLarge = Functions.FindNthLargestNumber(lst, 3);
            Assert.AreEqual(nthLarge,22);
           
        }

        [TestMethod]
        public void TestSelectPrimeNumbers()
        {
            List<int> lst = new List<int> {0, 1, 2, 3, 4, 19, 122,100,119 };
            List<int> lstprime = new List<int> {  2, 3, 19 };
            List<int> lstout = (List<int>) Functions.SelectPrimeNumbers(lst);
            CollectionAssert.AreEqual(lstout, lstprime);

        }

        [TestMethod]
        public void TestIsPalindrome()
        {
           
            bool Palin = Functions.IsPalindrome(3);
            Assert.IsFalse(Palin);

        }

        [TestMethod]
        public void TestCountSetBits()
        {

            int count = Functions.CountSetBits(117);
            Assert.AreEqual(count,5);

        }
    }
}
