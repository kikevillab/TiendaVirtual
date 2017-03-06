using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public partial class Ticket
    {
        public Ticket(int id, ShoppingCart cc, string user)
        {
            this.Id = id;
            this.CreationDate = DateTime.Now;
            this.Status = "Pending";
            this.TicketProducts = new HashSet<TicketProduct>(cc.ToList());
            this.User = user;
            this.TotalPrice = cc.TotalPrice;
        }
    }
}