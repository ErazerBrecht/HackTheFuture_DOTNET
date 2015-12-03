
namespace HackTheFuture
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public partial class NewPeople
    { 
        /// <summary>
        /// Initializes a new instance of the NewPeopleExtension class.
        /// </summary>
        public void Create(People p)
        {
            this.Agility = p.Agility;
            this.Charisma = p.Charisma;
            this.DateOfBirth = p.DateOfBirth;
            this.Endurance = p.Endurance;
            this.FirstName = p.FirstName;
            this.Id = p.Id;
            this.Intelligence = p.Intelligence;
            this.LastName = p.LastName;
            this.Luck = p.Luck;
            this.Perception = p.Perception;
            this.Sex = p.Sex;
            this.Strength = p.Strength;
        }
    }
}