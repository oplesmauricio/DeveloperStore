using AutoMapper;
using SalesApi.Application.Commands;
using SalesApi.Domain.Entities;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        ProductMapper();
        SaleMapper();
        SaleItemMapper();
    }

    private void SaleItemMapper()
    {
        //Dominio mapeando para DTO de entrada e saida
        CreateMap<SaleItem, SalesApi.Application.DTO.Response.SaleItemDto>();
        CreateMap<SalesApi.Application.DTO.Request.SaleItemDto, SaleItem>();

        //Entidades de banco mapeando para DTO de entrada e saida
        CreateMap<SalesApi.Infrastructure.Entities.SaleItemEntity, SalesApi.Application.DTO.Response.SaleItemDto>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.IsCanceled, opt => opt.MapFrom(src => src.Sale.IsCanceled));
        CreateMap<SalesApi.Application.DTO.Request.SaleItemDto, SalesApi.Infrastructure.Entities.SaleItemEntity>();

        //Dominio mapeando para Entidades de banco
        CreateMap<SaleItem, SalesApi.Infrastructure.Entities.SaleItemEntity>();
        CreateMap<SalesApi.Infrastructure.Entities.SaleItemEntity, SaleItem>();
    }

    private void SaleMapper()
    {
        //Dominio mapeando para DTO de entrada e saida
        CreateMap<Sale, SalesApi.Application.DTO.Response.SaleDto>();
        CreateMap<SalesApi.Application.DTO.Request.SaleDto, Sale>();

        //Entidades de banco mapeando para DTO de entrada e saida
        CreateMap<SalesApi.Infrastructure.Entities.SaleEntity, SalesApi.Application.DTO.Response.SaleDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate))
            .ForMember(dest => dest.Canceled, opt => opt.MapFrom(src => src.IsCanceled))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalValue));
        CreateMap<SalesApi.Application.DTO.Request.SaleDto, SalesApi.Infrastructure.Entities.SaleEntity>();

        //Dominio mapeando para Entidades de banco
        CreateMap<Sale, SalesApi.Infrastructure.Entities.SaleEntity>();
        CreateMap<SalesApi.Infrastructure.Entities.SaleEntity, Sale>();
    }

    private void ProductMapper()
    {
        //Dominio mapeando para DTO de entrada e saida
        CreateMap<Product, SalesApi.Application.DTO.Response.ProductDto>();
        CreateMap<CreateProductCommand, Product>();

        //Entidades de banco mapeando para DTO de entrada e saida
        CreateMap<SalesApi.Infrastructure.Entities.ProductEntity, SalesApi.Application.DTO.Response.ProductDto>();
        CreateMap<CreateProductCommand, SalesApi.Infrastructure.Entities.ProductEntity>();

        //Dominio mapeando para Entidades de banco
        CreateMap<Product, SalesApi.Infrastructure.Entities.ProductEntity>();
        CreateMap<SalesApi.Infrastructure.Entities.ProductEntity, Product>();
    }
}
