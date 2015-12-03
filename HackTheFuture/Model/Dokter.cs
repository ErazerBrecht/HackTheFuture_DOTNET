using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Dokter : Arbeid
    {
        public Dokter()
        {
            Naam = "Dokter";

            MinStrength = 1;
            MaxStrength = 2;
            MinPerception = 3;
            MaxPerception = 3;
            MinEndurance = 1;
            MaxEndurance = 2;
            MinCharisma = 1;
            MaxCharisma = 3;
            MinIntelligence = 3;
            MaxIntelligence = 4;
            MinAgility = 1;
            MaxAgility = 3;
            MinLuck = 1;
            MaxLuck = 3;
        }
    }
}
