using MediatR;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {

        private readonly IRepository<Order> _repository;

        public GetOrderQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderQueryResult
            {
                OrderDate = x.OrderDate,
                OrderId = x.OrderId,
                TotalPrice=x.TotalPrice,
                UserId=x.UserId,
            }).ToList();
        }
    }
}
