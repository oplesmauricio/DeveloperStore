using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Querys.SAles;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Handlers.Sale
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, Result<IEnumerable<SaleDto>>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SaleDto>>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var salesEntity = _saleRepository.GetAll();

            return Result.Ok(salesEntity.Select(p => _mapper.Map<DTO.Response.SaleDto>(p)));
        }
    }
}
