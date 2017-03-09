namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfNullOrEmpty(value, "Company name can't be null or empty");
                Validator.CheckIfLessNumberOfSymbols(value, 5, "Company name can't be less than 5 symbols");
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            set
            {
                Validator.CheckIfExactNumberOfSymbols(value, 10, "Registration number must be exactly exactly 10 symbols");
                Validator.CheckIfAllSymbolsAreDigits(value, "Registration number contain only digits");
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            throw new NotImplementedException();
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}
