using AutoMapper;
using Entity;
using Entity.DTOs.Advert;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertsController : ControllerBase
{
    private readonly IAdvertService _service;
    private readonly IMapper _mapper;

    public AdvertsController(IMapper mapper, IAdvertService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("GetAllPopulated")]
    public async Task<IActionResult> GetAllPopulated()
    {
        var result = await _service.GetAllPopulatedAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    [HttpGet("GetAllPopulatedByCategory")]
    public async Task<IActionResult> GetAllPopulatedByCategory(int id)
    {
        var result = await _service.GetAllByCategoryPopulatedAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AdvertAddDto advertAddDto)
    {
        var advert = _mapper.Map<Advert>(advertAddDto);
        var result = await _service.AddAsync(advert);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}