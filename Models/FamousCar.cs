using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Autopedia.Models
{
    [Keyless]
    public partial class FamousCar
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4000)]
        public string Model { get; set; }
        [Required]
        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(4000)]
        public string PhotoUrl { get; set; }
    }
}
