using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Commands
{
    public record AddProductCommand(Product Product) :IRequest;

    
}
