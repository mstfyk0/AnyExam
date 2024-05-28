using MediatR;
using OrderApi.Application.Features.Meditor.Command.UserCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {

        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateUserCommandHandler(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Create(new User
            {
                UserName = request.UserName,
                Password = request.Password,
            });
            await _unitOfWork.Commit();
        }
    }
}
