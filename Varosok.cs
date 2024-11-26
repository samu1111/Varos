using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Varos
{
    internal class Varosok
    {
        public string VarosNeve { get; set; }
        public string OrszagNeve { get; set; }
        public decimal NepessegM { get; set; }

        public Varosok(string sor)
        {
            string[] v = sor.Split(';');
            VarosNeve = v[0];
            OrszagNeve = v[1];
            NepessegM = decimal.Parse(v[2]) * 1000000;
        }
    }
}
