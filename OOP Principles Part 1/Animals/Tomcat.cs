namespace Telerik.Homeworks.OOP.Principles.Animals
{
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age = 1)
            : base(name, Gender.Male, age)
        {
        }

        public override string Speak()
        {
            return $"Pur, pur I'm {this.Name} a {this.Age} {this.YearsWord} old tomcat";
        }
    }
}