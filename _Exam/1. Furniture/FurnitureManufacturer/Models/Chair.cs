using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair, IFurniture
    {
        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs) : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; private set; }
    }
}
