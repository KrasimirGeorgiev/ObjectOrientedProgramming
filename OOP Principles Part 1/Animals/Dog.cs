namespace Telerik.Homeworks.OOP.Principles.Animals
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, Gender gender, int age = 1)
            : base(name, gender, age)
        {
        }

        public override string Speak()
        {
            return $"Bark, bark I'm {this.Name} the dog and I'm {this.Age} {this.YearsWord} old";
        }
    }
}
