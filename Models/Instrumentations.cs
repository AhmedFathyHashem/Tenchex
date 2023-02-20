using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
    public enum InstrumentType
    {
		[Display(Name = "Pressure Gauge")] PressureGauge = 0,
		[Display(Name = "Pressure Transmitter")] PressureTransmitter = 1,
		[Display(Name = "DP Gauge")] DPGauge = 2,
		[Display(Name = "DP Transmitter")] DPTransmitter = 3,
		[Display(Name = "Temperature Transmitter")] TemperatureTransmitter = 4,
		[Display(Name = "Temperature Gauge")] TemperatureGauge = 5

    }
    public class Instrumentations
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InstrumentationId { get; set; }
        [Required]
        public InstrumentType InstrumentType { get; set; }
        public int? PressureGaugeId { get; set; }
        public int? PressureTransmitterId { get; set; }
        public int? DiffrentialPressureGaugeId { get; set;}
        public int? DiffrentialPressureTransmitterId { get; set;}
        public int? TemperatureTransmitterId { get;set; }
        public int? TemperatureGaugeId { get; set;}

        public virtual PressureGauge? PressureGauge { get; set;}
        public virtual PressureTransmitter? PressureTransmitter { get;set;}
        public virtual DiffrentialPressureGauge? DiffrentialPressureGauge { get;set;}
        public virtual DiffrentialPressureTransmitter? DiffrentialPressureTransmitter { get;set;}
        public virtual TemperatureGauge? TemperatureGauge { get; set;}
        public virtual TemperatureTransmitter?  TemperatureTransmitter { get; set;}


    }
}
