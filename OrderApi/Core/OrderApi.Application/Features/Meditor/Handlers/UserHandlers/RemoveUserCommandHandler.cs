using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.UserCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {

        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveUserCommandHandler(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            if(values != null)
            {
                _repository.Delete(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(request.Id);
            }
        }
    }
}
