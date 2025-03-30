using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Ticketing.Application.Carts;
public sealed class Cart
{
    public Guid CustomerId { get; init; }

    public List<CartItem> Items { get; init; } = [];

    internal static Cart CreateDefault(Guid customerId) => new() { CustomerId = customerId };
}
