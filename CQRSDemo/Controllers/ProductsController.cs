using CQRSDemo.Commands;
using CQRSDemo.Models;
using CQRSDemo.Notifications;
using CQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;
        public ProductsController(ISender _sender, IPublisher _publisher)
        {
            this._sender = _sender;
            this._publisher = _publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _sender.Send(new AddProductCommand(product));

            await _publisher.Publish(new ProductAddedNotification(product));

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductById(id));
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
           await _sender.Send(new DeleteProductQuery(id));
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var productToreturn = await _sender.Send(new UpdateProductCommand(product));
            return Ok(product);
        }
    }
}
