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
        public int? Id { get; set; }
        [Column(TypeName = "text")]
        public string Model { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
