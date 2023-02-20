using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class Tanks
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TankId { get; set; }
		[Required]
		[StringLength(20)]
		public string? KKS { get; set; }
		[Required]
		[StringLength(20)]
		[DisplayName("Tank Dimensions")]
		public string? TankDimensions { get; set; }
		public virtual ICollection<Types> Types { get; } = new List<Types>();
	}
}
