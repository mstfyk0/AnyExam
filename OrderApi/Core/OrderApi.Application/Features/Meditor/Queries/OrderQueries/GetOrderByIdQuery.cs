using MediatR;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.Meditor.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
