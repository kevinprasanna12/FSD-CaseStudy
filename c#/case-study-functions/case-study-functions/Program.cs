using System;

namespace case_study_functions
{
  

    class Program
    {
        
        static int CalculateFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be non-negative.");

            int result = 1;
            for (int i = 1; i <= number; i++)
                result *= i;
            return result;
        }

        
        static double CalculateSimpleInterest(double principal, double rate, double time)
        {
            if (principal < 0 || rate < 0 || time < 0)
                throw new ArgumentException("Principal, Rate, and Time must be non-negative.");

            return (principal * rate * time) / 100;
        }

       
        static void CalculateInterestAndTotal(double principal, double rate, double time, out double interest, out double totalAmount)
        {
            if (principal < 0 || rate < 0 || time < 0)
                throw new ArgumentException("Principal, Rate, and Time must be non-negative.");

            interest = (principal * rate * time) / 100;
            totalAmount = principal + interest;
        }

        static double CalculateSIWithOptionalRate(double principal, double time, double rate = 10)
        {
            if (principal < 0 || time < 0)
                throw new ArgumentException("Principal, Rate, and Time must be non-negative.");

            return (principal * rate * time) / 100;
        }

        static void Main()
        {
            
            try
            {
                Console.Write("Enter number for factorial: ");
                int num = int.Parse(Console.ReadLine());
                int fact = CalculateFactorial(num);
                Console.WriteLine($"Factorial of {num} is {fact}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in factorial: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\n--- Simple Interest Calculation ---");
                Console.Write("Enter Principal: ");
                double principal = double.Parse(Console.ReadLine());

                Console.Write("Enter Rate: ");
                double rate = double.Parse(Console.ReadLine());

                Console.Write("Enter in years: ");
                double time = double.Parse(Console.ReadLine());

                double si = CalculateSimpleInterest(principal, rate, time);
                Console.WriteLine($"Simple Interest: {si}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in simple interest calculation: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\n--- Simple Interest & Total Amount---");
                Console.Write("Enter Principal: ");
                double principal2 = double.Parse(Console.ReadLine());

                Console.Write("Enter Rate: ");
                double rate2 = double.Parse(Console.ReadLine());

                Console.Write("Enter Time: ");
                double time2 = double.Parse(Console.ReadLine());

                CalculateInterestAndTotal(principal2, rate2, time2, out double interest, out double total);
                Console.WriteLine($"Interest: {interest}, Total Payable Amount: {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in interest & total calculation: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\n--- Simple Interest (@Rate = 10%) ---");
                Console.Write("Enter Principal: ");
                double principal3 = double.Parse(Console.ReadLine());

                Console.Write("Enter in years: ");
                double time3 = double.Parse(Console.ReadLine());

                double result = CalculateSIWithOptionalRate(principal3, time3);
                Console.WriteLine($"Simple Interest (default 10%): {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in optional parameter interest calculation: " + ex.Message);
            }
        }
    }

}
