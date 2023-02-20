using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenchex.Models
{
	public class DiffrentialPressureGauge
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DiffrentialPressureGaugeId { get; set; }

		public string? Kks { get; set; }
		[DisplayName("Model Number")]
		public string? ModelNumber { get; set; }
		[DisplayName("Area Classification")]
		public string? AreaClassification { get; set; }

		public string? Ip { get; set; }
		[DisplayName("Element Material")]
		public string? ElementMaterial { get; set; }
		[DisplayName("Process Connection Material")]
		public string? ProcessConnectionMaterial { get; set; }
		[DisplayName("Span Range")]
		public short? SpanRange { get; set; }
		public byte? Accuracy { get; set; }

		public byte? Repeatabilty { get; set; }

		public string? Standard { get; set; }
		[DisplayName("Mounting Bracket")]
		public Boolean? MountingBracket { get; set; }
		[DisplayName("Mounting Bracket Material")]
		public string? MountingBracketMaterial { get; set; }
		[DisplayName("Case Material")]
		public string? CaseMaterial { get; set; }
		[DisplayName("Dial Size")]
		public short? DialSize { get; set; }
		[DisplayName("Case Filling")]
		public string? CaseFilling { get; set; }
		[DisplayName("Glass Type")]
		public string? GlassType { get; set; }
		[DisplayName("Over Pressure Protection")]
		public Boolean? OverPressureProtector { get; set; }
		[DisplayName("Blow Out Protection")]
		public Boolean? BlowOutProtection { get; set; }

		public Boolean? Siphone { get; set; }

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
