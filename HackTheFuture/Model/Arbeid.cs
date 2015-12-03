using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTheFuture.Model
{
    public abstract class Arbeid
    {
        protected int MinStrength;
        protected int MaxStrength;
        protected int MinPerception;
        protected int MaxPerception;
        protected int MinEndurance;
        protected int MaxEndurance;
        protected int MinCharisma;
        protected int MaxCharisma;
        protected int MinIntelligence;
        protected int MaxIntelligence;
        protected int MinAgility;
        protected int MaxAgility;
        protected int MinLuck;
        protected int MaxLuck;

        public string Naam { get; set; }

        public virtual bool Check(People p)
        {
            if (p.Strength >= MinStrength && p.Strength <= MaxStrength)
            {
                if (p.Perception >= MinPerception && p.Perception <= MaxPerception)
                {
                    if (p.Endurance >= MinEndurance && p.Endurance <= MaxEndurance)
                    {
                        if (p.Charisma >= MinCharisma && p.Charisma <= MaxCharisma)
                        {
                            if (p.Intelligence >= MinIntelligence && p.Intelligence <= MaxIntelligence)
                            {
                                if (p.Agility >= MinAgility && p.Agility <= MaxAgility)
                                {
                                    if (p.Luck >= MinLuck && p.Luck <= MaxLuck)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
