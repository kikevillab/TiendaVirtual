using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models
{
    public class ShoppingCartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShoppingCart cc = (ShoppingCart) controllerContext.HttpContext.Session["cart"];
            if (cc == null)
            {
                cc = new ShoppingCart();
                controllerContext.HttpContext.Session["cart"] = cc;
            }

            return cc;
        }
    }
}