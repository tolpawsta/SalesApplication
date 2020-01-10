using System;
using System.Collections.Generic;

namespace SalesApp.BL.Models
{
    public class ManagerBL
    {
        public ManagerBL()
        {
            this.Report = new HashSet<ReportBL>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ReportId { get; set; }
        public virtual ICollection<ReportBL> Report { get; set; }
    }
}
