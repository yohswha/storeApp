using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeApp.Models
{
    public class PurchaseOrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal Subtotal => Quantity * UnitPrice;
    }
}