using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore _fakeDataStore)
        {
                this._fakeDataStore = _fakeDataStore;
        }
        public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
           
            return await _fakeDataStore.GetProductById(request.id);
        }
    }
}
