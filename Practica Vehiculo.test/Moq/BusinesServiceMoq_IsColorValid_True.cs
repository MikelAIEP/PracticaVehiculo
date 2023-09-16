using Practica_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Vehiculo.test.Moq
{
    internal class BusinesServiceMoq_IsColorValid_True : IBusinesService
    {
        public bool ColorIsValid(string color)
        {
            return true;
        }
    }
}
