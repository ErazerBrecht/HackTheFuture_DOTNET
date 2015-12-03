using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class GeheimAgent : Arbeid
    {
        public GeheimAgent()
        {
            Naam = "Geheim agent";

            MinStrength = 1;
            MaxStrength = 4;
            MinPerception = 3;
            MaxPerception = 4;
            MinEndurance = 2;
            MaxEndurance = 4;
            MinCharisma = 2;
            MaxCharisma = 4;
            MinIntelligence = 3;
            MaxIntelligence = 4;
            MinAgility = 3;
            MaxAgility = 4;
            MinLuck = 3;
            MaxLuck = 4;
        }
       
    }
}
