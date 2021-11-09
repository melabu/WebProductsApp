using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebProducts.Models
{
    [Table("Product")]
    public class Product
    {
        [Key()]
        public int Id { get; set; }

        [StringLength(150)]
        public string Category { get; set; }

        [DisplayName("Name")]
        [StringLength(150)]
        public string ProductName { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [DisplayName("Available Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime AvailableDate { get; set; }
    }
}