using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.Meditor.Command.UserCommands
{
    public class RemoveUserCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}
