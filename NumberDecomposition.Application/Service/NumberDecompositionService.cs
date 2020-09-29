using NumberDecomposition.Application.Interface;
using System;
using System.Collections.Generic;

namespace NumberDecomposition.Application.Service
{
    public class NumberDecompositionService : INumberDecompositionService
    {
        public NumberDecompositionService()
        {                        
        }                

        /// <summary>
        /// Valida se o número recebido é primo
        /// </summary>
        /// <param name="numbers"></param>
        /// <summary>
        /// Valida se um número é primo
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Decompõe um número para achar e armazenar seus divisores
        /// </summary>
        /// <param name="v"></param>
        public List<int> Decomposition(int number)
        {
            var numberDivisors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    numberDivisors.Add(i);
                }
            }

            return numberDivisors;
        }

        /// <summary>
        /// Realiza decomposição de um número e encontra os números primos contidos na decomposição
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<int> GetPrimeNumbersFromDecomposition(int number)
        {
            var primeNumbers = new List<int>();
            var numberDivisors = Decomposition(number);

            numberDivisors.ForEach(x =>
            {
                if (IsPrime(x))
                {
                    primeNumbers.Add(x);
                }
            });

            return primeNumbers;
        }
    }
}
