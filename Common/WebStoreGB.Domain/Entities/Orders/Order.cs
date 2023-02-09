using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Base;
using WebStoreGB.Domain.Entities.Identity;

namespace WebStoreGB.Domain.Entities.Orders
{
    public class Order : Entity
    {
        [Required]
        public User User { get; set; }

        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }


        public string Description { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        [NotMapped]
        public decimal TotalPrice => Items?.Sum(x => x.TotalItemPrice) ?? 0m;
    }
}
