using MediatR;
using OrderApi.Application.Features.Meditor.Results.ProductResults;


namespace OrderApi.Application.Features.Meditor.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
