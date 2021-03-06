using AutoMapper;
using Entity;
using Entity.DTOs.Advert;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Service.Aspects.Security;

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

    [SecuredAction("admin,standard_user")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [SecuredAction("standard_user")]
    [HttpGet("GetAllPopulated")]
    public async Task<IActionResult> GetAllPopulated()
    {
        var result = await _service.GetAllPopulatedAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    [SecuredAction("standard_user")]
    [HttpGet("GetAllPopulatedByCategory")]
    public async Task<IActionResult> GetAllPopulatedByCategory(int id)
    {
        var result = await _service.GetAllByCategoryPopulatedAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    [SecuredAction("standard_user")]
    [HttpPost]
    public async Task<IActionResult> Add(AdvertAddDto advertAddDto)
    {
        var advert = _mapper.Map<Advert>(advertAddDto);
        var userId = 
        advert.user_id = Int32.Parse(HttpContext.User.Claims.First().Value);
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