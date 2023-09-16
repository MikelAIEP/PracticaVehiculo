using Practica_Vehiculo.Entities;

namespace Practica_Vehiculo.Services
{
    public interface IVehiculoService
    {
        bool ColorIsValid(string color);
        Task Insert(Vehiculo entity);
        Task<bool> PatenteExist(string patente);
    }
}
