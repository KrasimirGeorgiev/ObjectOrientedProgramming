namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.MaterialType = materialType;
        }
        public virtual decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Validator.CheckIfLessOrEqualToZero(value, "Furniture's height can't be less or equal to 0");
                this.height = value;
            }
        }

        public MaterialType MaterialType { get; set; }

        public string Material
        {
            get
            {
                return this.MaterialType.ToString();
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                Validator.CheckIfNullOrEmpty(value, "Furniture model can't be null or empty");
                Validator.CheckIfLessNumberOfSymbols(value, 3, "Furniture model can't be less than 3 symbols");
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validator.CheckIfLessOrEqualToZero(value, "Furniture price can't be less or equal to 0");
                this.price = value;
            }
        }
    }
}
