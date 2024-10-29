using System.ComponentModel.DataAnnotations;

namespace PugaIsaac_EvaluacionProgeso1.Models
{
    public class Celular
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(2000,2025)]//5
        public int Año { get; set; }

        public double Precio { get; set; }

    }
}
