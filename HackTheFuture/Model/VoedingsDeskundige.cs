using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class VoedingsDeskundige : Arbeid
    {
        public VoedingsDeskundige()
        {
            Naam = "VoedingsDeskundige";

            MinStrength = 0;
            MaxStrength = 2;
            MinPerception = 0;
            MaxPerception = 3;
            MinEndurance = 1;
            MaxEndurance = 4;
            MinCharisma = 0;
            MaxCharisma = 1;
            MinIntelligence = 1;
            MaxIntelligence = 3;
            MinAgility = 2;
            MaxAgility = 3;
            MinLuck = 1;
            MaxLuck = 4;
        }
    }
}
