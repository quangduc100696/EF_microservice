using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Command
{
    public interface ICommand<out TResponse> : IRequest<TResponse> { }

    public interface ICommand : IRequest
    {
    }
}
