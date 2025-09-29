using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class Currency
    {
        public string name;
        public string code;
        public double rate;

        public Currency(string name, string code, double rate)
        {
            this.name = name;
            this.code = code;
            this.rate = rate;
        }
    }
}
