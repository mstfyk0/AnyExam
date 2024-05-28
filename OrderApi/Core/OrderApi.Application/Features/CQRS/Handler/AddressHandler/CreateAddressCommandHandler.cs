using OrderApi.Application.Features.CQRS.Commands.AddressCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAddressCommandHandler(IRepository<Address> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            _repository.Create(new Address
            {
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                Detail = createAddressCommand.Detail,
                UserId = createAddressCommand.UserId
            });
            await _unitOfWork.Commit();
        }
    }
}
