using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class ordehandhaver : Arbeid
    {
        public ordehandhaver()
        {
            Naam = "ordehandhaver";

            MinStrength = 3;
            MaxStrength = 4;
            MinPerception = 3;
            MaxPerception = 4;
            MinEndurance = 2;
            MaxEndurance = 3;
            MinCharisma = 0;
            MaxCharisma = 4;
            MinIntelligence = 1;
            MaxIntelligence = 2;
            MinAgility = 2;
            MaxAgility = 4;
            MinLuck = 1;
            MaxLuck = 3;
        }
    }
}
