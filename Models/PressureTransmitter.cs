using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class PressureTransmitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PressureTransmitterId { get; set; }
		public string? Kks { get; set; }
		[DisplayName("Model Number")]
		public string? ModelNumber { get; set; }
		[DisplayName("Area Classification")]
		public string? AreaClassification { get; set; }

		public string? Ip { get; set; }
		[DisplayName("Element Material")]
		public string? ElementMaterial { get; set; }
		[DisplayName("Housing Material")]
		public string? HousingMaterial { get; set; }
		[DisplayName("Process Connection Material")]
		public string? ProcessConnectionMaterial { get; set; }
		[DisplayName("Span Range")]
		public short? SpanRange { get; set; }
		[DisplayName("Callibration Range")]
		public short? CallibrationRange { get; set; }
		[DisplayName("Sensor Type")]
		public string? SensorType { get; set; }

		public byte? Accuracy { get; set; }

		public byte? Repeatabilty { get; set; }

		public string? Standard { get; set; }

		public Boolean? Lcd { get; set; }

		public Boolean? KeyPad { get; set; }

		public string? Protocol { get; set; }

		public Boolean? _420mA { get; set; }
		public Boolean? Installation { get; set; }
		[DisplayName("Mounting Bracker")]
		public Boolean? MountingBracket { get; set; }
		[DisplayName("Mounting Bracket Material")]
		public string? MountingBracketMaterial { get; set; }
		public Boolean? Manifold { get; set; }
		[DisplayName("Manifol Type")]
		public string? ManifoldType { get; set; }
		[DisplayName("Manifold Material")]
		public string? ManifoldMaterial { get; set; }
		[DisplayName("Diaphragm Seal")]
		public Boolean? DiaphragmSeal { get; set; }
		[DisplayName("Diaphragm Seal Material")]
		public string? DiaphragmSealMaterial { get; set; }
		[DisplayName("Cabillary Tubes")]
		public Boolean? CabillaryTubes { get; set; }
		[DisplayName("Cabillary Tubes Material")]
		public string? CabillaryTubesMaterial { get; set; }
		public virtual ICollection<Instrumentations> Instrumentations { get; } = new List<Instrumentations>();
	}
}
