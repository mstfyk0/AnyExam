using MediatR;
using OrderApi.Application.Features.Meditor.Results.UserResults;


namespace OrderApi.Application.Features.Meditor.Queries.OrderQueries
{
    public class GetUserQuery : IRequest<List<GetUserQueryResult>>
    {


    }
}
