using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    class Elektrisch_ingenieur : Arbeid
    {
        public Elektrisch_ingenieur()
        {
            Naam = "Elektronische ingenieur";

            MinStrength = 1;
            MaxStrength = 2;
            MinPerception = 2;
            MaxPerception = 3;
            MinEndurance = 1;
            MaxEndurance = 2;
            MinCharisma = 0;
            MaxCharisma = 1;
            MinIntelligence = 2;
            MaxIntelligence = 3;
            MinAgility = 2;
            MaxAgility = 3;
            MinLuck = 1;
            MaxLuck = 3;
        }
        
    }
}
