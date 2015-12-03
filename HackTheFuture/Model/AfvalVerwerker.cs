using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class AfvalVerwerker : Arbeid
    {
        public AfvalVerwerker()
        {
            Naam = "Afvel verwerker";

            MinStrength =     2;
            MaxStrength =     3;
            MinPerception =   2;
            MaxPerception =   3;
            MinEndurance =    2;
            MaxEndurance =    2;
            MinCharisma =     0;
            MaxCharisma =     1;
            MinIntelligence = 3;
            MaxIntelligence = 4;
            MinAgility =      2;
            MaxAgility =      3;
            MinLuck =         3;
            MaxLuck =         4;
        }
    }
}
