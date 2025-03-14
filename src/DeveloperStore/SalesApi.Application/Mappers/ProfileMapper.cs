using AutoMapper;
using SalesApi.Domain.Entities;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<Product, SalesApi.Application.DTO.Response.ProductDto>();
        
        CreateMap<SalesApi.Application.DTO.Request.ProductDto, Product>();


    }
}
