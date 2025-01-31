using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RentACar.Models
{
    public class VehicleResultDto : VehicleDto
    {
        public Guid Id { get; set; }
    }

    public class VehicleDto
    {
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        public string? Type { get; set; }

        public string? Fuel { get; set; }

        public string? TopSpeed { get; set; }

        public string? Color { get; set; }

        public string? RegistritationDate { get; set; }
    }
}
