using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Ticketing.Application.Carts;
public sealed class CartItem
{
    public Guid TicketTypeId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; }
}
