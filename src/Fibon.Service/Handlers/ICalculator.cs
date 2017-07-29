using System;

namespace Fibon.Service.Handlers
{
    public interface ICalculator
    {
        int Fib(int number);
    }

    public class Calculator : ICalculator
    {
        public int Fib(int number)
        {
            // not optimal
            // TODO add this to IOC
            /*switch (number)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Fib(number -2) + Fib(number - 1);
            }*/
            int a = 0;
            int b = 1;
            for (int i = 0; i < number; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}
