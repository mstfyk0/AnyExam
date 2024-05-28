using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.UserQueries;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {

        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            if (values != null)
            {
                return new GetUserByIdQueryResult
                {
                    UserId = values.UserId,
                    UserName = values.UserName,
                    Password = values.Password
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
