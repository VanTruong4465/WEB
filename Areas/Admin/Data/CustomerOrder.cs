//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonsal_Gardent.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerOrder()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.OrderDetails1 = new HashSet<OrderDetail>();
        }
    
        public int ID { get; set; }
        public int AccCustomerID { get; set; }
        public Nullable<System.DateTime> CreateAtTime { get; set; }
    
        public virtual AccCustomer AccCustomer { get; set; }
        public virtual AccCustomer AccCustomer1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails1 { get; set; }
    }
}
