using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberDecomposition.Application.Interface;

namespace NumberDecomposition.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecompositionController : ControllerBase
    {
        private readonly INumberDecompositionService _numberDecompositionService;

        public DecompositionController(INumberDecompositionService numberDecompositionService)
        {
            _numberDecompositionService = numberDecompositionService;
        }

        [HttpPost("decompositionDivisors")]
        public ActionResult<IEnumerable<int>> DecompositionDivisors(int number)
        {
            return _numberDecompositionService.Decomposition(number);
        }

        [HttpPost("decompositionPrimes")]
        public ActionResult<IEnumerable<int>> DecompositionPrimes(int number)
        {
            return _numberDecompositionService.GetPrimeNumbersFromDecomposition(number);
        }
    }
}
