using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ValidBox
{
    public class ValidString
    {
        /* Función que detecta si la cadena contiene únicamente números, ya sea con signo(sign=S) o sin signo(sign=U). */
        public static bool isNumeric(string txt, char sign = 'U')
        {
            int len = txt.Length;
            bool signed = false;
            int i;
            /* Para detectar si existe el signo '+' or '-' en el string. */
            if ((sign == 'S') && (len != 1) && (txt[0] == '-' || txt[0] == '+')) 
                signed = true;
             for (i = (signed) ? (1) : (0); i != len; ++i)
             {
                     if(!(txt[i] >= '0' && txt[i] <= '9'))
                         return false;
             }
            return true;
        }

        /* Función que detecta si la cadena contiene únicamente letras. */
        public static bool isLetter(string txt)
        {
            for (int i = txt.Length - 1; i != -1; --i)
            {
                if (txt[i] == ' ') 
                    continue;
                switch (txt[i])
                {
                    case 'á':
                        break;
                    case 'é':
                        break;
                    case 'í':
                        break;
                    case 'ó':
                        break;
                    case 'ú':
                        break;
                    case 'Á':
                        break;
                    case 'É':
                        break;
                    case 'Í':
                        break;
                    case 'Ó':
                        break;
                    case 'Ú':
                        break;
                    case 'ñ':
                        break;
                    case 'Ñ':
                        break;
                    default:
                        if (!((txt[i] >= 'A' && txt[i] <= 'Z') || (txt[i] >= 'a' && txt[i] <= 'z'))) 
                            return false;
                        break;
                }
            }
            return true;
        }

        /* Función que detecta si la cadena contiene únicamente decimales, ya sea con signo(sign=S) o sin signo(sign=U). */
        public static bool isFloat(string txt, char sign = 'U')
        {
            int len = txt.Length;
            bool pointFloat = false;
            bool comaFloat = false;
            bool signed = false;
            int i;
            /* Para detectar si existe un '.' or ',' al inicio o final del string. */
            if ((txt[0] == '.' || txt[0] == ',') || (txt[len - 1] == '.' || txt[len - 1] == ',')) 
                return false;
            /* Para detectar si existe un signo '+' or '-' al inicio del string. */
            if ((sign == 'S') && (len != 1) && (txt[0] == '-' || txt[0] == '+')) 
                signed = true;
            for (i = (signed) ? (1) : (0); i != len; ++i)
            {
                /* Para permitir un punto en el string. */
                if (!pointFloat && txt[i] == '.')
                {
                    /* Para evitar que a lado del punto haya un punto o una coma */
                    if((txt[i] == '.' && txt[i+1] == ',') || (txt[i] == '.' && txt[i+1] == '.')) 
                        return false;
                    pointFloat = true;
                }
                /* Para permitir una coma en el string. */
                else if (!comaFloat && txt[i] == ',')
                {
                    /* Para evitar que a lado de la coma haya un punto o una coma */
                    if((txt[i] == ',' && txt[i+1] == '.') || (txt[i] == ',' && txt[i+1] == ',')) 
                        return false;
                    comaFloat = true;
                }
                else if (!(txt[i] >= '0' && txt[i] <= '9'))
                    return false;
            }
            return true;
        }

        /* Función que convierte la cadena decimal a double, ya sea con signo o sin signo */
        public static double ToDouble(string txt, char sign = 'U')
        {
		    double n;
            NumberStyles style = (sign != 'U') ? 
                (NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign) : (NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands);
		    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            if (!Double.TryParse(txt, style, culture, out n))
                MessageBox.Show("Error: No se pudo convertir de String a Double.");
            return n;
        }

    }
}
