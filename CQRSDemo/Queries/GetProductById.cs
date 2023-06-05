using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Queries
{
    public record GetProductById(int id) : IRequest<Product>;
   
}
