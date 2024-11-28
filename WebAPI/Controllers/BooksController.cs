using Business.Abstracts;
using Business.Dtos.Requests.BookRequests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookRequest createBookRequest)
        {
            var result = await _bookService.AddAsync(createBookRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequest updateBookRequest)
        {
            var result = await _bookService.UpdateAsync(updateBookRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _bookService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _bookService.GetById(id);
            return Ok(result);
        }
    }
}
