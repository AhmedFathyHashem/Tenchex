using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class Systems
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SystemId { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("System Name")]
		public string? SystemName { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("System Fluid")]
		public string? SystemFluid { get; set; }
		[Required]
		public int ProjectID { get; set; }

		public virtual ICollection<Equipments> Equipments { get; } = new List<Equipments>();
		public virtual Projects? Projects { get; set; }
	}
}
