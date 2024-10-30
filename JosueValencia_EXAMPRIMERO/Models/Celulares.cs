using System.ComponentModel.DataAnnotations;

namespace JosueValencia_EXAMPRIMERO.Models
{
    public class Celulares
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Modelo { get; set; }

        [Range(2000, 2024)]
        public int Anio { get; set; }

        public float Precio { get; set; }
    }
}
