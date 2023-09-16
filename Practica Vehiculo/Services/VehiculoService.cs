 using Microsoft.EntityFrameworkCore;
using Practica_Vehiculo.Entities;

namespace Practica_Vehiculo.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBusinesService _businesService;

        public VehiculoService(ApplicationDbContext context , IBusinesService businesService )
        {
            _context = context;
            _businesService = businesService;
        }

        public async Task<bool> PatenteExist(string patente)
        {
           var patenteExist = await _context.Vehiculos.AnyAsync(x => x.Patente == patente);
            if (patenteExist)
            {
                return true;
            } else {
                       return false;
                   }

        }

        public bool ColorIsValid(string color) 
        {
            var result = _businesService.ColorIsValid(color);
            return result;
        }

        public async Task Insert(Vehiculo entity)
        {
            _context.Vehiculos.Add(entity);
            await _context.SaveChangesAsync();

        }

    }
}
