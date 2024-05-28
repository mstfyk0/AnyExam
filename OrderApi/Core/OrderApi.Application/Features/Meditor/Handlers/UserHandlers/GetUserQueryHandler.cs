using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {

        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            if (values != null)
            {

                return values.Select(x => new GetUserQueryResult
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password=x.Password,
                }).ToList();
            }
            throw new NotFoundException();

        }
    }
}
