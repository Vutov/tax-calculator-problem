using System;

namespace Simple
{
    class Program
    {
        private static double _minTaxValue = 1000;
        private static double _maxSocialValue = 3000;
        
        static void Main(string[] args)
        {
            var income = double.Parse(Console.ReadLine());

            if (income <= _minTaxValue)
            {
                Console.WriteLine(income);
                return;
            }

            var tax = (income - _minTaxValue) * 0.1;
            var socialTaxable = (income - _minTaxValue);
            if (income > _maxSocialValue)
            {
                socialTaxable = _maxSocialValue - _minTaxValue;
            }

            var socialTax = socialTaxable * 0.15;
            var net = income - (tax + socialTax);
            Console.WriteLine(net);
        }
    }
}