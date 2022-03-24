using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Autopedia.Models
{
    public partial class Car
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Brand { get; set; }
        [Required]
        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(4000)]
        public string PhotoUrl { get; set; }
    }
}
