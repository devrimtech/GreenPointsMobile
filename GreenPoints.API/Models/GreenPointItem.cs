using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenPoints.API.Models
{
    public class GreenPointItem
    {
        // Needed for the cards
        public int Points { get; set; }
        public bool IsComplete { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        // Private because the value should be automatically set and only needed for checking when the item was completed. 
        public DateTime time { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
