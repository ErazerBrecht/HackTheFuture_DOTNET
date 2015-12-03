using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Energie : Arbeid
    {
        public Energie()
        {
            Naam = "Arbeid";

            MinStrength = 0;
            MaxStrength = 2;
            MinPerception = 2;
            MaxPerception = 4;
            MinEndurance = 0;
            MaxEndurance = 2;
            MinCharisma = 0;
            MaxCharisma = 2;
            MinIntelligence = 2;
            MaxIntelligence = 3;
            MinAgility = 2;
            MaxAgility = 3;
            MinLuck = 1;
            MaxLuck = 4;
        }
        
    }
}
