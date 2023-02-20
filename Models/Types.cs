using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{

	public class Types
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TypeId { get; set; }
		public int? InstrumentId { get; set; }
		public int? CableId { get; set; }
		public int? PipeId { get; set; }
		public int? CompressorId { get; set; }
		public int? TankId { get; set; }
		public int? PumpId { get; set; }
		public int? ValveId { get; set; }
		public virtual ICollection<Equipments> Equipments { get; } = new List<Equipments>();
		public virtual Instrumentations? Instrumentations { get; set; }
		public virtual Cables? Cables { get; set; }
		public virtual Pipes? Pipes { get; set; }
		public virtual Compressors? Compressors { get; set; }
		public virtual Tanks? Tanks { get; set; }
		public virtual Pumps? Pumps { get; set; }
		public virtual Valves? Valves { get; set; }
	}
}
