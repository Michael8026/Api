using api.Dtos;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _repository;

        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if ((!ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }

            var stocks = await _repository.GetAllAsync(query);

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _repository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createStockDto)
        {
            var stock = createStockDto.ToStockFromCreateDto();

            await _repository.CreateAsync(stock);

            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var stock = await _repository.UpdateAsync(id, updateStockDto);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());



        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _repository.DeleteAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return NoContent();

        }



    }
}
