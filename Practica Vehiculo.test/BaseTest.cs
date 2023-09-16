using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Vehiculo.test
{
   public class BaseTest
    {
      
            // Inicializar la base de datos
            protected ApplicationDbContext BuildDataBaseContext(string dbName)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: dbName)
                    .Options;
                var dbContext = new ApplicationDbContext(options);
                return dbContext;
            }
        
    }
}
