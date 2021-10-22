using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private IBaseService<Loan> _baseLoanService;
        public LoanController(IBaseService<Loan> baseLoanService)
        {
            _baseLoanService = baseLoanService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Loan loan)
        {
            if (loan == null)
                return NotFound();

            return Execute(() => _baseLoanService.Add<LoanValidator>(loan).Id);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Loan loan)
        {
            if (loan == null)
                return NotFound();

            return Execute(() => _baseLoanService.Update<LoanValidator>(loan));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseLoanService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseLoanService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseLoanService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
