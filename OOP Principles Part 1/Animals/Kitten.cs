namespace Telerik.Homeworks.OOP.Principles.Animals
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age = 1)
            : base(name, Gender.Female, age)
        {
        }

        public override string Speak()
        {
            return $"Myaaauuu, myau says me {this.Name} the {this.Age} {this.YearsWord} old kitty";
        }
    }
}