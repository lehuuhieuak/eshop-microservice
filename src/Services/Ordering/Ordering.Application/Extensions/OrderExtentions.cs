namespace Ordering.Application.Extensions;

public static class OrderExtentions
{
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => new OrderDto
        (
            Id: order.Id.Value,
            CustomerId: order.CustomerId.Value,
            OrderName: order.OrderName.Value,
            ShippingAddress: new AddressDto
            (
                FirstName: order.ShippingAddress.FirstName,
                LastName: order.ShippingAddress.LastName,
                EmailAddress: order.ShippingAddress.EmailAddress,
                AddressLine: order.ShippingAddress.AddressLine,
                State: order.ShippingAddress.State,
                ZipCode: order.ShippingAddress.ZipCode,
                Country: order.ShippingAddress.Country
            ),
            BillingAddress: new AddressDto
            (
                FirstName: order.BillingAddress.FirstName,
                LastName: order.BillingAddress.LastName,
                EmailAddress: order.BillingAddress.EmailAddress,
                AddressLine: order.BillingAddress.AddressLine,
                State: order.BillingAddress.State,
                ZipCode: order.BillingAddress.ZipCode,
                Country: order.BillingAddress.Country
            ),
            Payment: new PaymentDto
            (
                CardName: order.Payment.CardName,
                CardNumber: order.Payment.CardNumber,
                Expiration: order.Payment.Expiration,
                Cvv: order.Payment.CVV,
                PaymentMethod: order.Payment.PaymentMethod
            ),
            Status: order.Status,
            OrderItems: order.OrderItems.Select(oi => new OrderItemDto
            (
                ProductId: oi.ProductId.Value,
                OrderId: oi.OrderId.Value,
                Quantity: oi.Quantity,
                Price: oi.Price
            )).ToList()
        ));
    }
}
