using System;
using Xunit;
using NumberDecomposition.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using NumberDecomposition.Application.Interface;

namespace NumberDecompositionTests
{
    public class NumberServiceTest
    {
        private ServiceProvider _serviceProvider { get; set; }

        /// <summary>
        /// Construtor para resolver injeção de dependência
        /// </summary>
        public NumberServiceTest()
        {
            var services = new ServiceCollection();

            services.AddScoped<INumberDecompositionService, NumberDecompositionService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Teste para realizar decomposição de um número e validar que quantidade de divisores do número passado seja maior que zero
        /// </summary>
        [Fact]
        public void NumberDivisorsListCountIsGreaterThanZeroTest()
        {
          
            var service = _serviceProvider.GetService<INumberDecompositionService>();
            
            var numberDivisors = service.Decomposition(3);

            Assert.True(numberDivisors.Count == 2);
            Assert.True(numberDivisors[0] == 1);
            Assert.True(numberDivisors[1] == 3);
        }

        /// <summary>
        /// Teste para tentar fazer decomposição de um número em que não é possível decompor
        /// </summary>
        [Fact]
        public void NumberDivisorsListCountIsNotGreaterThanZeroTest()
        {
            var service = _serviceProvider.GetService<INumberDecompositionService>();

            var numberDivisors = service.Decomposition(0);

            Assert.True(numberDivisors.Count == 0);            
        }

        /// <summary>
        /// Teste para realizar decomposição de um número e validar os números primos contidos na decomposição
        /// </summary>
        [Fact]
        public void PrimeNumberListCountIsGreaterThanZeroTest()
        {

            var service = _serviceProvider.GetService<INumberDecompositionService>();

            var numberDivisors = service.GetPrimeNumbersFromDecomposition(3);

            Assert.True(numberDivisors.Count == 1);
            Assert.True(numberDivisors[0] == 3);
        }

        /// <summary>
        /// Teste para realizar decomposição de um número em que não é possível decompor e também não existira número primo contido na decomposição
        /// </summary>
        [Fact]
        public void PrimeNumberListCountIsNotGreaterThanZeroTest()
        {

            var service = _serviceProvider.GetService<INumberDecompositionService>();

            var numberDivisors = service.GetPrimeNumbersFromDecomposition(0);

            Assert.True(numberDivisors.Count == 0);
        }
    }
}
