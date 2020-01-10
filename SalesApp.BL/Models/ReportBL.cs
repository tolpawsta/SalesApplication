using System.Collections.Generic;

namespace SalesApp.BL.Models
{
    public class ReportBL
    {
        public ReportBL()
        {
            this.Order = new HashSet<OrderBL>();
        }

        public int Id { get; set; }
        public int ManagerId { get; set; }
        public System.DateTime ReportDate { get; set; }

        public virtual ManagerBL Manager { get; set; }

        public virtual ICollection<OrderBL> Order { get; set; }
    }
}
