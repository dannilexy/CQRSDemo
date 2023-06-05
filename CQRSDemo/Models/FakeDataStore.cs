namespace CQRSDemo.Models
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product{Id =1, Name = "Text Product 1"},
                new Product{Id =2, Name = "Text Product 2"},
                new Product{Id =3, Name = "Text Product 3"}
            };

        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<List<Product>> GetProductsAsync() => await Task.FromResult( _products );
        public async Task<Product?> GetProductById(int id) => await Task.FromResult( _products.FirstOrDefault( x => x.Id == id));
        public async Task DeleteProduct(Product product)
        {
            _products?.Remove(product);
            await Task.CompletedTask;
        }
        public async Task UpdateProduct(Product productquery)
        {
           var product = _products.FirstOrDefault(x=>x.Id == productquery.Id);
            if (product != null)
            {
                product.Name = productquery.Name;
            }
            await Task.CompletedTask;
        }
        public async Task EventOccured(Product product, string evt)
        {
            _products.FirstOrDefault(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
