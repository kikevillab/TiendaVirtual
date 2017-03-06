using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public partial class TicketProduct
    {
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else if(this.Id == ((TicketProduct)obj).Id)
            {
                return true;
            }

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}