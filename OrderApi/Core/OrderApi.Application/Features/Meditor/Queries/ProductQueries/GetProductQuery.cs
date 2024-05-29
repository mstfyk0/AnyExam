using MediatR;
using OrderApi.Application.Features.Meditor.Results.ProductResults;


namespace OrderApi.Application.Features.Meditor.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {


    }
}
