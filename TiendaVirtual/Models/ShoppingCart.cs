using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public class ShoppingCart : List<TicketProduct>
    {
        public double TotalPrice { get; set; }

        public ShoppingCart()
        {
            TotalPrice = 0;
        }


        public new void Add(TicketProduct product)
        {
            if (!this.Contains(product))
            {
                base.Add(product);
            }
            else
            {
                base.Find(p => p.Id == product.Id).Cuantity += product.Cuantity;
            }

            TotalPrice += product.Cuantity * product.Price;
        }

        public void Clean()
        {
            this.Clear();
            this.TotalPrice = 0;
        }


    }
}