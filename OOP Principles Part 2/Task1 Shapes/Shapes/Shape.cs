namespace Telerik.Homeworks.OOP.Principles.Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;

        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                this.ValidateSide(value);
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.ValidateSide(value);
                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        private void ValidateSide(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Shape sides must be greater than zero");
            }
        }
    }
}
