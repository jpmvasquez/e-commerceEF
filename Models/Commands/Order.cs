using E_Commerce_Project.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Project.Models.Commands
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public string userId { get; set; }
        [ForeignKey(nameof(userId))]
        public ApplicationUser user { get; set; }

        public List<OrderItem> orderItems { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime orderDate { get; set; }
    }
}
