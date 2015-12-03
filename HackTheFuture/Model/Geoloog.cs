using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Geoloog : Arbeid
    {
        public Geoloog()
        {
            Naam = "Geoloog";

            MinStrength = 2;
            MaxStrength = 4;
            MinPerception = 2;
            MaxPerception = 4;
            MinEndurance = 1;
            MaxEndurance = 2;
            MinCharisma = 0;
            MaxCharisma = 2;
            MinIntelligence = 1;
            MaxIntelligence = 4;
            MinAgility = 0;
            MaxAgility = 2;
            MinLuck = 0;
            MaxLuck = 3;
        }

        
    }
}
