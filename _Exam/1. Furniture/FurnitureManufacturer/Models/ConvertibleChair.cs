using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair, IFurniture
    {
        private bool isConverted;
        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs) : base(model, materialType, price, height, numberOfLegs)
        {
            this.isConverted = false;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            this.isConverted = !this.isConverted;
        }

        public override decimal Height
        {
            get
            {
                if (isConverted)
                {
                    return 0.1M;
                }
                return base.Height;
            }

            set
            {
                base.Height = value;
            }
        }
    }
}
