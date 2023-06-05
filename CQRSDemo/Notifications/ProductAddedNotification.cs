using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
  
}
