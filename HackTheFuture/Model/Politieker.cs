using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Politieker : Arbeid
    {
        public Politieker()
        {
            Naam = "Politieker";

            MinStrength =     0;
            MaxStrength =     2;
            MinPerception =   3;
            MaxPerception =   4;
            MinEndurance =    1;
            MaxEndurance =    3;
            MinCharisma =     4;
            MaxCharisma =     4;
            MinIntelligence = 0;
            MaxIntelligence = 4;
            MinAgility =      2;
            MaxAgility =      4;
            MinLuck =         2;
            MaxLuck =         4;
        }
    }
}
