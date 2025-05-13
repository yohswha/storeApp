using System;
using System.ComponentModel.DataAnnotations;

namespace storeApp.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(11)]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }


    }
}

