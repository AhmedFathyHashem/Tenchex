using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class Suppliers
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SupplierId { get; set;}
		[Required]
		[StringLength(50)]
		[DisplayName("Supplier Name")]
		public string? SupplierName { get; set;}
		[Required]
		[StringLength(30)]
		[DisplayName("Supplier Origin")]
		public string? SupplierOrigin { get; set; }
		public virtual ICollection<Equipments> Equipments { get;} = new List<Equipments>();
		

	}
}
