using _07.Military.Interfaces;

namespace _07.Military.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, string id, decimal salary) : base (firstName, lastName, id) 
        {
            Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}
