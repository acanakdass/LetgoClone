using AutoMapper;
using Core.Entities.Concrete;
using Entity.DTOs.OperationClaim;

namespace Service.Mappers;

public class OperationClaimMapper:Profile
{
    public OperationClaimMapper()
    {
        CreateMap<OperationClaim, OperationClaimAddDto>().ReverseMap();
    }
}