using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
    public class Pipes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PipeId { get; set; }
        [Required]
        [StringLength(50)]
        public string? KKS { get; set; }
        [Required]
		[DisplayName("Nominal Diameter")]
		public short NominalDiameter  { get; set; }
        [Required]
        [StringLength(50)]
        public string? Material { get; set; }

        public virtual ICollection<Types> Types { get; } = new List<Types>();
    }
}
