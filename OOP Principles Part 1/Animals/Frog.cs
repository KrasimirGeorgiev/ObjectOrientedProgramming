namespace Telerik.Homeworks.OOP.Principles.Animals
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, Gender gender, int age = 1)
            : base(name, gender, age)
        {
        }

        public override string Speak()
        {
            return $"Ribbit, ribbit, I'm {this.Name} the frog and I'm {this.Age} {this.YearsWord} old";
        }
    }
}