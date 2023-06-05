using CQRSDemo.Commands;
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product?>
    {
        private readonly FakeDataStore _fakeDataStore;
        public UpdateProductHandler(FakeDataStore _fakeDataStore)
        {
            this._fakeDataStore = _fakeDataStore;
        }
        public Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _fakeDataStore.UpdateProduct(request.Product);
           var productToReturn = _fakeDataStore.GetProductById(product.Id);
            return productToReturn;
        }
    }
}
