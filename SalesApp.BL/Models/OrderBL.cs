namespace SalesApp.BL.Models
{
    public class OrderBL
    {
        public long Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public int ReportId { get; set; }

        public virtual CustomerBL Customer { get; set; }
        public virtual ProductBL Product { get; set; }
        public virtual ReportBL Report { get; set; }
    }
}
