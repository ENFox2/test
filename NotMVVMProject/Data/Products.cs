namespace NotMVVMProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Products : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            MaterialToProduct = new List<MaterialToProduct>();
        }

        [Key]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public string ImagePath { get; set; }

        public byte[] Image { get; set; }

        public decimal TotalPrice {
            get => MaterialToProduct.Sum(p => Convert.ToDecimal(p.Materials.Price)); 
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<MaterialToProduct> MaterialToProduct { get; set; }
    }
}
