using System.ComponentModel.DataAnnotations;

namespace Practica_Vehiculo.DTO.VehiculoDTO
{
    public class VehiculoCreateDTO
    {
        
        [Required(ErrorMessage = "El Valor Patente es requerido")]
        public string Patente { get; set; }

        public int Marca { get; set; }

        public int Modelo { get; set; }

        public string? Color { get; set; }

        public int Carroceria { get; set; }
    }
}
