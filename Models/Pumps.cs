using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public enum PumpTypes
	{
		Vertical = 0,
		Horizontal= 1,
		Submirsable = 2
	}
	public class Pumps
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PumpId
		{
			get; set;
		}
		[Required]
		[StringLength(20)]
		public string? KKS { get; set; }
		[Required]
		[DisplayName("Pump Types")]
		public PumpTypes PumpTypes { get; set; }
		public virtual ICollection<Types> Types { get; } = new List<Types>();
	}
}
