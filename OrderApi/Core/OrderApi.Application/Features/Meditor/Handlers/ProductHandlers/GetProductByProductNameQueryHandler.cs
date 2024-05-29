//using MediatR;
//using OrderApi.Application.Exceptions;
//using OrderApi.Application.Interfaces;
//using OrderApi.Domain.Entities;


//namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
//{
//    public class GetProductByProductNameQueryHandler : IRequestHandler<GetProductByProductNameQuery, GetProductByProductNameQueryResult>
//    {

//        private readonly IRepository<Product> _repository;

//        public GetProductByProductNameQueryHandler(IRepository<Product> repository)
//        {
//            _repository = repository;
//        }

//        public async Task<GetProductByProductNameQueryResult> Handle(GetProductByProductNameQuery request, CancellationToken cancellationToken)
//        {
//            var values = await _repository.GetByProductNameAsync(request.ProductName);

//            if (values != null)
//            {
//                return new GetProductByProductNameQueryResult
//                {
//                    ProductId = values.ProductId,
//                    ProductName = values.ProductName,
//                    Password = values.Password
//                };
//            }
//            throw new NotFoundProductNameException(request.ProductName);
//        }
//    }
//}
