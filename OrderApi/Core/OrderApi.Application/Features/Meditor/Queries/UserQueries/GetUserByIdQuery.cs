using MediatR;
using OrderApi.Application.Features.Meditor.Results.UserResults;


namespace OrderApi.Application.Features.Meditor.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResult>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
