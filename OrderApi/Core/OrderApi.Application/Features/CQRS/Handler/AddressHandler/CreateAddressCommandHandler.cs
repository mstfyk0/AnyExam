using OrderApi.Application.Features.CQRS.Commands.AddressCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                Detail = createAddressCommand.Detail,
                UserId = createAddressCommand.UserId
            });
        }
    }
}
