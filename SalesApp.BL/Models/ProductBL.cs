using System.Collections.Generic;

namespace SalesApp.BL.Models
{
    public class ProductBL
    {
        public ProductBL()
        {
            this.Order = new HashSet<OrderBL>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<OrderBL> Order { get; set; }
    }
}
