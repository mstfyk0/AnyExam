using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.UserCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {

        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateUserCommandHandler(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.UserId);

            if (values != null)
            {
                values.UserId = request.UserId;
                values.UserName = request.UserName;
                values.Password = request.Password;
                _repository.Update(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(request.UserId);
            }
        }
    }
}
