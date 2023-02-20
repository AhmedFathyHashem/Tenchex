using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
	public enum Departments
	{
		Instrumrntation = 1,
		DCS = 2,
		Process = 3,
		Civil = 4,
		MEP = 5,
		[Display(Name = "Plant Design")] PlantDesign = 6,
		Electrical = 7,
		Procurement = 8,
		Porposals = 9,
		Planning = 10,
		Cost = 11,
		Contracts = 12,
		PEM = 13,
		PM = 14,
		Digital = 15
	}
	public class Employees
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("First Name")]
		public string? FirstName { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("Last Name")]
		public string? LastName { get; set; }
		[Required]
		[EmailAddress]
		[DisplayName("Email Address")]
		public string? EmailAddress { get; set; }
		[Required]
		public Departments Departments { get; set; }

		public virtual ICollection<Equipments> Equipments { get; } = new List<Equipments>();

	}
}
