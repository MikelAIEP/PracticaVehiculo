namespace Practica_Vehiculo.Services
{
    public class BusinesService : IBusinesService
    {
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
   }
}
