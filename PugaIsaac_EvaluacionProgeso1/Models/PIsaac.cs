using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PugaIsaac_EvaluacionProgeso1.Models
{
    public class PIsaac
    {
        [Key]//1
        [Required]//2
        public int Id { get; set; }
        [MaxLength(100)]//3
        public string Nombre { get; set; }    


        public bool Soltero { get; set; }
        
        public DateTime FechaDeCompra { get; set; }

        public double Sueldo { get; set; }

        public Celular? Celular { get; set; }

        [ForeignKey("Celular")]//4
        public int IdCelular { get; set; }




    }
}
