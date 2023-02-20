using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tenchex.Models
{
    public enum EquipmentCategory
    {
		[Display(Name = "Project Specs")] ProjectSpecs = 0,
        Offer = 1,
        Ordered = 2
    }
    public enum EquipmentType
    {
        Instruments = 0,
        Valves = 1,
        Pumps = 2,
        Tanks = 3,
        Compressors = 4,
        Pipes = 5,
        cables = 6
    }
    public enum Currency
    {
        EGP = 0,
        USD = 1,
        EUR = 2,
        AED = 3,
        GBP = 4
    }
    public class Equipments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }
        [Required]
		[DisplayName("Equipment Category")]
		public EquipmentCategory EquipmentCategory { get; set; }
        [Required]
        public EquipmentType Type { get; set; }
        [Required]
		[DisplayName("Unite Price")]
		public float? UnitePrice { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public short Quantities { get; set; }
        [Required]
		[DisplayName("Vendor")]
		public int VendorID { get; set; }
        [Required]
		[DisplayName("Supplier")]
		public int SupplierId { get; set; }
        [Required]
		[DisplayName("Employee")]
		public int EmployeeId { get; set; }
        [Required]
		[DisplayName("Type")]
		public int TypeId { get; set; }
        [Required]
		[DisplayName("System")]
		public int SystemId { get; set; }
        public virtual Types? Types { get; set; }
        public virtual Employees? Employees { get; set; }
        public virtual Suppliers? Suppliers { get; set; }
        public virtual Vendors? Vendors { get; set; }
        public virtual Systems? Systems { get; set; }
    }
}
