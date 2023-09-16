using System.ComponentModel.DataAnnotations;

namespace Practica_Vehiculo.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [MaxLength(6)]
        public string Patente { get; set; }

        public int Marca { get; set; }

        public int Modelo { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }

        public int Carroceria { get; set; }



    }
}
