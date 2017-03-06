using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class ShoppingCartController : Controller
    {
        private tiendaVirtualEntities db = new tiendaVirtualEntities();

        // GET: ShoppingCart
        public ActionResult Index(ShoppingCart cc)
        {
            return View(cc);
        }

        public ActionResult Buy(ShoppingCart cc, int id, int cuantity)
        {
            Product product = db.Products.Find(id);            
            if (product == null)
            {
                return HttpNotFound();
            }
            TicketProduct ticketProduct = new TicketProduct();
            ticketProduct.Id = product.Id;
            ticketProduct.Name = product.Name;
            ticketProduct.Price = (double) product.Price;
            ticketProduct.Cuantity = cuantity;
            ticketProduct.CategoryId = product.Category.Id;
            ticketProduct.CategoryName = product.Category.Name;
            cc.Add(ticketProduct);
            return RedirectToAction("Index", "Products");
        }

        public ActionResult CreateTicket(ShoppingCart cc)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Ticket ticket = new Ticket(db.Tickets.Count() + 1, cc, User.Identity.Name);
  
            foreach(TicketProduct p in cc)
            {
                db.Products.Find(p.Id).Stock -= p.Cuantity;
            }

            db.Tickets.Add(ticket);
            db.SaveChanges();

            cc.Clean();
            
            return View(ticket);
        }

        
    }
}