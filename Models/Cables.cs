using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
    public enum CableType
    {
		Control = 0,
        Power = 1,
        DCS = 2,
        Instruments = 3
    }
    public class Cables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CableId { get; set; }
        [Required]
        [StringLength(20)]
        public string? KKS { get; set; }
        [Required]
        [StringLength(50)]
        public string? Size { get; set; }
        [Required]
        [DisplayName("Cable Type")]
        public CableType CableType { get; set; }

        public virtual ICollection<Types> Types { get; } = new List<Types>();
    }
}
