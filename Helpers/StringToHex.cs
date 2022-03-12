using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Takke.Helpers
{
    public class StringToHex
    {
        public static string ConvertStringToHex(string str)
        {
            var result = "";
            for (var i = 0; i < str.Length; i++)
            {
                string o = Convert.ToString(str[i], 16);

                if (o.Length == 1)
                {
                    result += "000" + o;
                }
                else if (o.Length == 2)
                {
                    result += "00" + o;
                }
                else if (o.Length == 3)
                {
                    result += "0" + o;
                }
                else
                {
                    result += o;
                }
            }
            return result;
        }
    }
}
