using Practica_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Vehiculo.test.Moq
{
    public class BusinesServiceMoq_IsColorValid_False : IBusinesService
    {
        public bool ColorIsValid(string color)
        {
            return false;
        }
    }
}
