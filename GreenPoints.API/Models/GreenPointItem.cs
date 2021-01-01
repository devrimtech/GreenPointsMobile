using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenPoints.API.Models
{
    public class GreenPointItem
    {
        private int Points { get; set; }
        private bool IsComplete { get; set; }
        private string Name { get; set; }
        private string? Description { get; set; }
        private DateTime time { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
