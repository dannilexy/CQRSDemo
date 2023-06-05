using MediatR;

namespace CQRSDemo.Queries
{
    public record DeleteProductQuery(int id) : IRequest;
   
}
