using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Geschiedkundige : Arbeid
    {
        public Geschiedkundige()
        {
            Naam = "Geschiedkundige";

            MinStrength = 0;
            MaxStrength = 2;
            MinPerception = 3;
            MaxPerception = 4;
            MinEndurance = 0;
            MaxEndurance = 3;
            MinCharisma = 0;
            MaxCharisma = 2;
            MinIntelligence = 2;
            MaxIntelligence = 3;
            MinAgility = 1;
            MaxAgility = 2;
            MinLuck = 3;
            MaxLuck = 4;
        }

        
    }
}
