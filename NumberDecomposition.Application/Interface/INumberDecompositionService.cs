using System.Collections.Generic;

namespace NumberDecomposition.Application.Interface
{
    public interface INumberDecompositionService
    {
        List<int> Decomposition(int number);        

        List<int> GetPrimeNumbersFromDecomposition(int number);
    }
}
