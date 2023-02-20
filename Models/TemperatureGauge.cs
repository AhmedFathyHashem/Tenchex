using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class TemperatureGauge
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TemperatureGaugeId { get; set; }
		public string? Kks { get; set; }
		[DisplayName("Model Number")]
		public string? ModelNumber { get; set; }
		[DisplayName("Area Classification")]
		public string? AreaClassification { get; set; }

		public string? Ip { get; set; }
		[DisplayName("Element Material")]
		public string? ElementMaterial { get; set; }
		[DisplayName("Process Connection To Thermowell")]
		public string? ProcessConnectionToThermowell { get; set; }
		[DisplayName("Process Connection Material")]

		public string? ProcessConnectionMaterial { get; set; }
		[DisplayName("Insertion Length")]
		public short? InsertionLength { get; set; }
		[DisplayName("Emersion Length")]
		public short? EmersionLength { get; set; }
		[DisplayName("Total Length")]
		public short? TotalLength { get; set; }
		[DisplayName("Wave Frequency Calculation")]
		public Boolean? WaveFrequencyCalculation { get; set; }
		[DisplayName("Stem Length")]
		public short? StemLength { get; set; }
		[DisplayName("Stem Diameter")]
		public byte? StemDiameter { get; set; }
		[DisplayName("Span Range")]
		public short? SpanRange { get; set; }
		[DisplayName("Sensor Type")]
		public string? SensorType { get; set; }

		public byte? Accuracy { get; set; }

		public byte? Repeatabilty { get; set; }

		public string? Standard { get; set; }
		[DisplayName("Thermowell Type")]
		public string? ThermowellType { get; set; }
		[DisplayName("Thermowell Process Connection")]
		public string? ThermowellProcessConnection { get; set; }
		[DisplayName("Thermowell Process Connection Material")]
		public string? ThermowellProcessConnectionMaterial { get; set; }
		[DisplayName("Case Material")]
		public string? CaseMaterial { get; set; }
		[DisplayName("Dial Size")]
		public short? DialSize { get; set; }
		[DisplayName("Case Filling")]
		public string? CaseFilling { get; set; }
		[DisplayName("Glass Type")]
		public string? GlassType { get; set; }
		public virtual ICollection<Instrumentations> Instrumentations { get; } = new List<Instrumentations>();
	}
}
