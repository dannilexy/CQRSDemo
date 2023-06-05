using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Queries
{
    public record GetProductQuery: IRequest<IEnumerable<Product>>;
    
}
