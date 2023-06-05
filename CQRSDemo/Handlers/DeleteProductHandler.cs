using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductQuery, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public DeleteProductHandler(FakeDataStore _fakeDataStore) =>this._fakeDataStore = _fakeDataStore;
        public async Task<Unit> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _fakeDataStore.GetProductById(request.id);
            if (product != null)
            {
               await _fakeDataStore.DeleteProduct(product);
            }

            return Unit.Value;
        }
    }
}
