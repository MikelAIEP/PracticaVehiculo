using Microsoft.EntityFrameworkCore;
using Practica_Vehiculo.Entities;

namespace Practica_Vehiculo.Services
{
    public class VehiculoServiceV2 : IVehiculoService
    {
        private readonly ApplicationDbContext _context;

        public VehiculoServiceV2(ApplicationDbContext context)
        {
            _context = context;
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
            bool v = Char.IsUpper(color[0]);
            if (v)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Insert(Vehiculo entity)
        {
            _context.Vehiculos.Add(entity);
            await _context.SaveChangesAsync();

        }
    }
}
