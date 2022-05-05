using AutoMapper;
using Entity;
using Entity.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
    {
        var category = _mapper.Map<Category>(categoryAddDto);
        var result = await _categoryService.AddAsync(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Delete(Category category)
    {
        var result = await _categoryService.UpdateAsync(category);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}