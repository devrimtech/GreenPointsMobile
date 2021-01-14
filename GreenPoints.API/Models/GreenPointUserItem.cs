using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenPoints.API.Models
{
    public class GreenPointUserItem
    {
        private string Email { get; set; }
        public string UserName { get; set; }
        public int CurrentPoints { get; set; }
        public DateTime JoinDate { get; set; }


        [Key]
        public int Id { get; set; }
    }
}
