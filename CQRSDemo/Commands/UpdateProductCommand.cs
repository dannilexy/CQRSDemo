using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Commands
{
    public record UpdateProductCommand(Product Product) : IRequest<Product?>;
    
}
