using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySqlNonDocker.Models
{
    public class WeatherForecast
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [Required]
        public int TemperatureC { get; set; }

        [NotMapped]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [StringLength(1000)]
        public string Summary { get; set; }
    }
}
