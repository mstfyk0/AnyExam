using MediatR;
using OrderApi.Application.Features.Meditor.Results.OrderResults;


namespace OrderApi.Application.Features.Meditor.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {


    }
}
