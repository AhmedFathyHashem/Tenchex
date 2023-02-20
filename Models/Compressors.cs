using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenchex.Models
{
    public enum CompressorType
	{
        Air = 0,
        Gas = 1
    }
    public class Compressors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompressorId { get; set; }
        [Required]
        [StringLength(20)]
        public string? KKS { get; set; }
        [Required]
        [DisplayName("Compressor Type")]
        public CompressorType CompressorType { get; set; }
        public virtual ICollection<Types> Types { get; } = new List<Types>();
    }
}
