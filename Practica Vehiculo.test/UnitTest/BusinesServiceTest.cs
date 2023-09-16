using Practica_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Vehiculo.test.UnitTest
{
    [TestClass]
    public class BusinesServiceTest
    {
        [TestMethod]
        public void ColorIsValid_ReturnFalse()
        {
            // Preparación
            var businesService = new BusinesService();
            var color = "rojo";
            // Ejecucion
            var result = businesService.ColorIsValid(color);

            // Validación

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ColorIsValid_ReturnTrue()
        {
            // Preparación
            var businesService = new BusinesService();
            var color = "Rojo";
            // Ejecucion
            var result = businesService.ColorIsValid(color);

            // Validación

            Assert.IsTrue(result);

        }

    }

}
