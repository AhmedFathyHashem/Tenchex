using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public class TemperatureTransmitter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TemperatureTransmitterId { get; set; }
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
		[DisplayName("Stem Legth")]
		public short? StemLength { get; set; }
		[DisplayName("Stem Diameter")]
		public byte? StemDiameter { get; set; }
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
		[DisplayName("Thermowell Type")]
		public string? ThermowellType { get; set; }
		[DisplayName("Thermowell Process Connection")]
		public string? ThermowellProcessConnection { get; set; }
		[DisplayName("Thermowell Process Connection Material")]
		public string? ThermowellProcessConnectionMaterial { get; set; }
		public virtual ICollection<Instrumentations> Instrumentations { get; } = new List<Instrumentations>();
	}
}
