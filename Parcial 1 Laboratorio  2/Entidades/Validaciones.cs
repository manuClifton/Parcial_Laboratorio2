using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Validaciones
    {

        public static bool ValidarDouble(string s, double max, double min)
        {

            return (double.TryParse(s, out double retorno) && retorno > min && retorno < max);
        }
        public static bool ValidarEntero(string s, int max, int min)
        {
            return (int.TryParse(s, out int retorno) && retorno > min && retorno < max);
        }
        public static bool ValidarFlotante(string s, float max, float min)
        {
            return (float.TryParse(s, out float retorno) && retorno > min && retorno < max);
        }
        public static bool ValidarString(string s)
        {
            return !(string.IsNullOrEmpty(s));
        }

    }
}
