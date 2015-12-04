using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    public class Kaartenmaker : Arbeid
    {
        public Kaartenmaker()
        {
            Naam = "Kaartenmaker";

            MinStrength = 0;
            MaxStrength = 1;
            MinPerception = 2;
            MaxPerception = 4;
            MinEndurance = 0;
            MaxEndurance = 3;
            MinCharisma = 0;
            MaxCharisma = 1;
            MinIntelligence = 1;
            MaxIntelligence = 3;
            MinAgility = 0;
            MaxAgility = 2;
            MinLuck = 1;
            MaxLuck = 4;
        }
    }
}
