namespace Telerik.Homeworks.OOP.Principles.Animals
{
    public abstract class Cat : Animal
    {
        protected Cat(string name, Gender gender, int age)
            : base(name, gender, age)
        {
        }
    }
}
