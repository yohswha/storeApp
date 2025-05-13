using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeApp.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        [MaxLength(20)]
        public string Status { get; set; } // "Pending", "Sent", etc.
        public List<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();

        [NotMapped]
        public decimal Total => Details?.Sum(d => d.Subtotal) ?? 0;
    }
}

