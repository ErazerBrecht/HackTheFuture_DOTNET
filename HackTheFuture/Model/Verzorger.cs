using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Verzorger : Arbeid
    {
        public Verzorger()
        {
            Naam = "Verzorger";

            MinStrength = 1;
            MaxStrength = 2;
            MinPerception = 2;
            MaxPerception = 3;
            MinEndurance = 3;
            MaxEndurance = 4;
            MinCharisma = 2;
            MaxCharisma = 3;
            MinIntelligence = 1;
            MaxIntelligence = 3;
            MinAgility = 3;
            MaxAgility = 4;
            MinLuck = 1;
            MaxLuck = 2;
        }
        
    }
}
