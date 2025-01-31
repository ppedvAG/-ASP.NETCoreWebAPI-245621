using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Models
{
    [PrimaryKey("Id")]
    public class Order
    {
        [Key, Column("OrderId")]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<AutoMobile> Items { get; set; }
    }
}
