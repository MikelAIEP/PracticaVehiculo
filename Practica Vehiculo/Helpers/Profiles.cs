using AutoMapper;
using Practica_Vehiculo.DTO.VehiculoDTO;
using Practica_Vehiculo.Entities;

namespace Practica_Vehiculo.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<VehiculoCreateDTO, Vehiculo>();
        }
    }
}
