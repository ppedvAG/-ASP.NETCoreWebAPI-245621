using System.Drawing;

namespace BusinessModel.Models
{
    public class AutoMobile
    {
        public long Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string Fuel { get; set; }

        public int TopSpeed { get; set; }

        public KnownColor Color { get; set; }

        public DateTime RegistritationDate { get; set; }
    }
}
