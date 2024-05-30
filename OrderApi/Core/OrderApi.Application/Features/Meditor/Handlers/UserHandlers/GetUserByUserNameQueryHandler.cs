using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.UserQueries;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, GetUserByUserNameQueryResult>
    {

        private readonly IRepository<User> _userRepository;

        public GetUserByUserNameQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByUserNameQueryResult> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetByUserNameAsync(request.UserName);

            if (values != null)
            {
                return new GetUserByUserNameQueryResult
                {
                    UserId = values.UserId,
                    UserName = values.UserName,
                    Password=values.Password
                };
            }
            return new GetUserByUserNameQueryResult {};
        }
    }
}
