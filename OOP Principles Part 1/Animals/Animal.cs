namespace Telerik.Homeworks.OOP.Principles.Animals
{
    using Validation;

    public abstract class Animal : ISound
    {
        protected Animal(string name, Gender gender, int age)
        {
            this.Age = Validator.ValidateNumber(age, 1, int.MaxValue);
            this.Gender = gender;
            this.Rename(name);
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public Gender Gender { get; }

        protected string YearsWord => this.Age == 1 ? "year" : "years";

        public abstract string Speak();

        public virtual void HappyBirthday()
        {
            this.Age++;
        }

        public void Rename(string newName)
        {
            this.Name = Validator.ValidateName(newName);
        }
    }
}
