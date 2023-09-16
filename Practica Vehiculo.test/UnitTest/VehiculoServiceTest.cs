using Microsoft.EntityFrameworkCore;
using Practica_Vehiculo.Entities;
using Practica_Vehiculo.Services;
using Practica_Vehiculo.test.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Vehiculo.test.UnitTest
{
    [TestClass]
    public class VehiculoServiceTest : BaseTest
    {
        [TestMethod]
        public async Task PatenteExist_ResultFalse()
        {
            // Preparacion
            var dbName = Guid.NewGuid().ToString();
            var Context1 = BuildDataBaseContext(dbName);
            var businesMoq = new BusinesServiceMoq();
            var service = new VehiculoService(Context1, businesMoq);
            var entity = new Vehiculo
            {
                Patente = "ABC123",
                Marca = 1,
                Modelo = 2,
                Color = "Rojo",
                Carroceria = 3
            };

            // Ejecucion
            var result = await service.PatenteExist(entity.Patente);

            // Verificacion
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task PatenteExist_ResultTrue()
        {
            // Preparacion
            var dbName = Guid.NewGuid().ToString();
            var Context1 = BuildDataBaseContext(dbName);
            var businesMoq = new BusinesServiceMoq();
            var service = new VehiculoService(Context1, businesMoq);
            var entity = new Vehiculo
            {
                Patente = "ABC123",
                Marca = 1,
                Modelo = 2,
                Color = "Rojo",
                Carroceria = 3
            };
            Context1.Vehiculos.Add(new Vehiculo
            {
                Patente = "ABC123",
                Marca = 1,
                Modelo = 2,
                Color = "Rojo",
                Carroceria = 3
            });
            await Context1.SaveChangesAsync();

            // Ejecucion
            var result = await service.PatenteExist(entity.Patente);

            // Verificacion
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ColorIsValid_ResultFalse()
        {
            // Preparacion
            var dbName = Guid.NewGuid().ToString();
            var Context1 = BuildDataBaseContext(dbName);
            var businesMoq = new BusinesServiceMoq_IsColorValid_False();
            var service = new VehiculoService(Context1, businesMoq);
            var color = "Rojo";

            // Ejecucion
            var result = service.ColorIsValid(color);

            // Verificacion
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ColorIsValid_ResultTrue()
        {
            // Preparacion
            var dbName = Guid.NewGuid().ToString();
            var Context1 = BuildDataBaseContext(dbName);
            var businesMoq = new BusinesServiceMoq_IsColorValid_True();
            var service = new VehiculoService(Context1, businesMoq);
            var color = "Rojo";

            // Ejecucion
            var result = service.ColorIsValid(color);

            // Verificacion
            Assert.IsTrue(result);
        }

        [TestMethod]

        public async Task Insert_ResultTrue()
        {
            // Preparacion
            var dbName = Guid.NewGuid().ToString();
            var Context1 = BuildDataBaseContext(dbName);
            var businesMoq = new BusinesServiceMoq_IsColorValid_True();
            var service = new VehiculoService(Context1, businesMoq);
            var entity = new Vehiculo
            {
                Patente = "ABC123",
                Marca = 1,
                Modelo = 2,
                Color = "Rojo",
                Carroceria = 3
            };

            // Ejecucion  
            await service.Insert(entity);
            var result = await Context1.Vehiculos.CountAsync();

            // Verificacion
            Assert.AreEqual(1, result);
        }
       
    }
}
