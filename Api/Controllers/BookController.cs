using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBaseService<Book> _baseBookService;
        public BookController(IBaseService<Book> baseBookService)
        {
            _baseBookService = baseBookService;
        }
        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null)
                return NotFound();

            return Execute(() => _baseBookService.Update<BookValidators>(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseBookService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseBookService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseBookService.GetById(id));
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
