namespace MobileDevices
{
    using System;
    using Contracts;

    public class FactoryProduct : IManufacturedItem
    {
        private string model;
        private string manufacturer;

        public FactoryProduct(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public int Id { get; protected set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model can't be empty");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer can't be empty");
                }

                this.manufacturer = value;
            }
        }

        public override string ToString()
        {

            string str = string.Empty;

            foreach (var prop in this.GetType().GetProperties())
            {
                var currentValue = prop.GetValue(this, null);
                if (currentValue is int || currentValue is float ||
                    currentValue is string || currentValue is Enum)
                {
                    str += $"{prop.Name,-15}: {currentValue}\n";
                }
                else
                {
                    str += $"\t{prop.Name}\n{currentValue}\n";
                }
            }

            return str;
        }
    }
}
