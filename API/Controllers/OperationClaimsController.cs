using AutoMapper;
using Core.Entities.Concrete;
using Entity.DTOs.OperationClaim;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController:ControllerBase
{
    private readonly IOperationClaimService _service;
    private readonly IMapper _mapper;

    public OperationClaimsController(IOperationClaimService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(OperationClaimAddDto addDto)
    {
        var operationClaim = _mapper.Map<OperationClaim>(addDto);
        var result = await _service.AddAsync(operationClaim);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(OperationClaim operationClaim)
    {
        var result = await _service.UpdateAsync(operationClaim);
        if (result.Success)
        {
            return Ok(result);
        }
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