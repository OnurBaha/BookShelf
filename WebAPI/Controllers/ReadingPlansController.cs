using Business.Abstracts;
using Business.Dtos.Requests.ReadingPlanRequests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingPlansController : ControllerBase
    {
        IReadingPlanService _readingPlanService;

        public ReadingPlansController(IReadingPlanService readingPlanService)
        {
            _readingPlanService = readingPlanService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateReadingPlanRequest createReadingPlanRequest)
        {
            var result = await _readingPlanService.AddAsync(createReadingPlanRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _readingPlanService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReadingPlanRequest updateReadingPlanRequest)
        {
            var result = await _readingPlanService.UpdateAsync(updateReadingPlanRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _readingPlanService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _readingPlanService.GetById(id);
            return Ok(result);
        }
    }
}
