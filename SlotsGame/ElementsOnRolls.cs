using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsGame
{
    class ElementsOnRolls
    {
        public ElementsOnRolls()
        { 
        }
        public ElementsOnRolls(string symbol, int value)
        {
            Symbol = symbol;
            Value = value;
        }
        public string Symbol { get; set; }
        public int Value { get; set; }
    }
}
