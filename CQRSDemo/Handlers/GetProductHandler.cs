using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductHandler(FakeDataStore _fakeDataStore)
        {
            this._fakeDataStore = _fakeDataStore;   
        }
        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductsAsync();
        }
    }
}
