using System.Collections.Generic;

namespace SalesApp.BL.Models
{
    public class CustomerBL
    {
        public CustomerBL()
        {
            this.Order = new HashSet<OrderBL>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<OrderBL> Order { get; set; }
    }
}
