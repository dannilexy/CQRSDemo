using CQRSDemo.Commands;
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly FakeDataStore _store;
        public AddProductHandler(FakeDataStore _store)
        {
            this._store = _store;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _store.AddProduct(request.Product);
            return Unit.Value;
        }

    }
}
