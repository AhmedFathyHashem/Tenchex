using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tenchex.Models
{
	public enum ProjectCategory
	{
		Tender = 0,
		[Display(Name = "In Progress")] InProgress = 1,
	}
	public enum ProjectType
	{
		[Display(Name = "Simple Cycle")] SimpleCycle = 0,
		[Display(Name = "Combined Cycle")] CombinedCycle = 1,
		HydroPower = 2,
		[Display(Name = "Pumping Station")] PumpingStation = 3,
		[Display(Name = "Water Treatment")] WaterTreatment = 4,
		CoGerneration = 5,
		[Display(Name = "Suber Critical")] SuberCritical = 6,
		SubStaion = 7,
	}
	public class Projects
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProjectId { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("Project Name")]
		public string? ProjectName { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("Project Location")]
		public string? ProjectLocation { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("Project Owner")]
		public string? ProjectOwner { get; set; }
		[StringLength(30)]
		[DisplayName("Project Consultant")]
		public string? ProjectConsultant { get; set; }
		[Required]
		[DisplayName("Project Category")]
		public ProjectCategory ProjectCatogry { get; set; }
		[Required]
		[DisplayName("Project Type")]
		public ProjectType ProjectType { get; set; }

		public virtual ICollection<Systems> Systems { get; } = new List<Systems>();

	}
}
