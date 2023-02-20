using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class Vendors
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int VendorID { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Vendor Name")]
		public string? VendorName { get; set; }
		[Required]
		[StringLength(20)]
		[DisplayName("Vendor Origin")]
		public string? VendorOrigin { get; set; }
		public virtual ICollection<Equipments> Equipments { get; } = new List<Equipments>();
	}
}
