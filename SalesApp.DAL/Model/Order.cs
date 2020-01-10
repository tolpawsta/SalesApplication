//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesApp.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public long Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public int ReportId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Report Report { get; set; }
    }
}
