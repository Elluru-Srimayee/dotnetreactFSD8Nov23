using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace SecondApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number,sum=0,avg=0;
            Console.WriteLine("Please enter 10 numbers to get their average");
            for (int i = 0; i < 10; i++) 
            {
               number = Convert.ToDouble(Console.ReadLine());
                sum +=number;
            }
            
            avg=sum/10;
            Console.WriteLine("The average of given 10 numbers is " + avg);
        }
    }
}
