using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeApp.Models
{
	public class Payment
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }//pending
    }
}

