using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Opvoeder : Arbeid
    {
        public Opvoeder()
        {
            Naam = "Opvoeder";

            MinStrength = 1;
            MaxStrength = 3;
            MinPerception = 3;
            MaxPerception = 4;
            MinEndurance = 2;
            MaxEndurance = 4;
            MinCharisma = 2;
            MaxCharisma = 3;
            MinIntelligence = 1;
            MaxIntelligence = 3;
            MinAgility = 2;
            MaxAgility = 4;
            MinLuck = 1;
            MaxLuck = 4;
        }

        
    }
}
