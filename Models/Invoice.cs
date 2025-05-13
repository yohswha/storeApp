using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public DateTime IssueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

    }
}

