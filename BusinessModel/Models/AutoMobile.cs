using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace BusinessModel.Models
{
    [PrimaryKey("Id")]
    public class AutoMobile
    {
        [Key, Column("VehicleId")]
        public Guid Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string Fuel { get; set; }

        public int TopSpeed { get; set; }

        public KnownColor Color { get; set; }

        public DateTime RegistritationDate { get; set; }
    }
}
