using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
    public enum ValveType
    {
        Manual = 0,
        Motorized = 1,
        Pneumatic = 2,
        Hydrolic = 3,
        CombinedCheck = 4,
        Control = 5
    }
    public enum BodyType
    {
        Gate = 0,
        Globe = 1,
        Ball = 2,
        ButterFly = 3
    }
    public class Valves
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ValveId { get; set; }
        [Required]
        [StringLength(20)]
        public string? KKS { get; set; }
        [Required]
		[DisplayName("Valve Type")]
		public ValveType ValveType { get; set; }
        [Required]
		[DisplayName("Body Type")]
		public BodyType BodyType { get; set; }
        public virtual ICollection<Types> Types { get; } = new List<Types>();
    }
}
